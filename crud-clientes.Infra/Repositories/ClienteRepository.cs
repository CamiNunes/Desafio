using crud_clientes.Domain.Entities;
using crud_clientes.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace crud_clientes.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connection;

        public ClienteRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.Query<Cliente>("SELECT ClienteID, Nome, Email, Logotipo FROM clientes");
            }
        }

        public async Task<Cliente> ObterPorIdAsync(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.QueryFirstOrDefault<Cliente>("SELECT * FROM clientes WHERE ClienteId = @Id", new { Id = id });
            }
        }

        public async Task<Cliente> GetClienteByEmail(string email)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                const string sql = "SELECT * FROM Clientes WHERE Email = @Email";
                return connection.QueryFirstOrDefault<Cliente>(sql, new { Email = email });
            }
        }

        public async Task InserirAsync(Cliente cliente)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                try
                {
                    var clienteFormatado = new Cliente()
                    {
                        Nome = cliente.Nome,
                        Email = cliente.Email,
                        Logotipo = cliente.Logotipo,
                    };

                    await connection.ExecuteAsync("InsertCliente", clienteFormatado, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                try
                {
                    var clienteFormatado = new Cliente()
                    {
                        ClienteId = cliente.ClienteId,
                        Nome = cliente.Nome,
                        Email = cliente.Email,
                        Logotipo = cliente.Logotipo,
                    };

                    await connection.ExecuteAsync("UpdateCliente", new
                    {
                        ClienteId = clienteFormatado.ClienteId,
                        Nome = clienteFormatado.Nome,
                        Email = clienteFormatado.Email,
                        Logotipo = clienteFormatado.Logotipo
                    }, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public async Task ExcluirAsync(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                try
                {
                    await connection.ExecuteAsync("DeleteClienteELogradouros", new { ClienteId = id }, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
