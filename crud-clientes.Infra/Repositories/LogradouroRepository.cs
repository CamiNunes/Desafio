using crud_clientes.Domain.Entities;
using crud_clientes.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace crud_clientes.Infra.Repositories
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private readonly string _connection;

        public LogradouroRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Logradouro>> ObterTodosAsync()
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.Query<Logradouro>("SELECT * FROM logradouros");
            }
        }

        public async Task<Logradouro> ObterPorIdAsync(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.QueryFirstOrDefault<Logradouro>("SELECT * FROM logradouros WHERE ClienteId = @Id", new { Id = id });
            }
        }

        public async Task InserirAsync(Logradouro logradouro)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                try
                {
                    var logradouroFormatado = new Logradouro()
                    {
                        ClienteId = logradouro.ClienteId,
                        Tipo = logradouro.Tipo,
                        Endereco = logradouro.Endereco,
                        Numero = logradouro.Numero,
                        Complemento = logradouro.Complemento,
                        Bairro = logradouro.Bairro,
                        Cidade = logradouro.Cidade,
                        UF = logradouro.UF,
                    };

                    await connection.ExecuteAsync("InsertLogradouro", logradouroFormatado, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        public async Task AtualizarAsync(Logradouro logradouro)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                try
                {
                    var logradouroFormatado = new Logradouro()
                    {
                        LogradouroId = logradouro.LogradouroId,
                        ClienteId = logradouro.ClienteId,
                        Tipo = logradouro.Tipo,
                        Endereco = logradouro.Endereco,
                        Numero = logradouro.Numero,
                        Complemento = logradouro.Complemento,
                        Bairro = logradouro.Bairro,
                        Cidade = logradouro.Cidade,
                        UF = logradouro.UF,
                    };

                    await connection.ExecuteAsync("UpdateLogradouro", new { ClienteId = logradouroFormatado.ClienteId, 
                                                                            LogradouroId = logradouroFormatado.LogradouroId, 
                                                                            Tipo = logradouroFormatado.Tipo,
                                                                            Endereco = logradouroFormatado.Endereco,
                                                                            Numero = logradouroFormatado.Numero,
                                                                            Complemento = logradouroFormatado.Complemento,
                                                                            Bairro = logradouroFormatado.Bairro,
                                                                            Cidade = logradouroFormatado.Cidade,
                                                                            UF = logradouroFormatado.UF,
                    }, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        public async Task ExcluirAsync(Guid id, Guid logradouroId)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                try
                {
                    await connection.ExecuteAsync("DeleteLogradouro", new { ClienteId = id, LogradouroId = logradouroId }, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
