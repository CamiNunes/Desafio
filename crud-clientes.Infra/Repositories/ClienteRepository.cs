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

        public Task AtualizarAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task InserirAsync(Cliente cliente)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                var clienteFormatado = new Cliente()
                {
                    Nome = cliente.Nome,
                    Email = cliente.Email
                };

                await connection.ExecuteAsync("InsertCliente", clienteFormatado, commandType: CommandType.StoredProcedure);
            }
        }

        public Task<Cliente> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        Task<Cliente> IClienteRepository.GetClienteByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
