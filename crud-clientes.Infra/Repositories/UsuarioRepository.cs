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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connection;

        public UsuarioRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Usuario> ObterUsuarioPorEmailAsync(string email)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                const string sql = "SELECT * FROM Usuarios WHERE Email = @Email";
                var result = connection.QueryFirstOrDefault<Usuario>(sql, new { Email = email });
                return result;
            }
        }

        public async Task InserirAsync(Usuario usuario)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                if (ObterUsuarioPorEmailAsync(usuario.Email).Result == null)
                {
                    var usuarioNovo = new Usuario()
                    {
                        Nome = usuario.Nome,
                        Email = usuario.Email,
                        SenhaHash = usuario.SenhaHash,
                    };

                    await connection.ExecuteAsync("InsertUsuario", usuarioNovo, commandType: CommandType.StoredProcedure);
                }
                else
                {
                    throw new InvalidOperationException("Um usuário com este email já está registrado.");
                }
            }
        }

        public Task ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
