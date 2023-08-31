using crud_clientes.Application.Interfaces;
using crud_clientes.Domain.Entities;
using crud_clientes.Domain.Interfaces.Repositories;
using crud_clientes.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace crud_clientes.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        static string GerarHashSenha(string senha)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private static bool VerificarHashSenha(string password, string hash)
        {
            string hashOfInput = GerarHashSenha(password);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hash) == 0;
        }

        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            return await _usuarioRepository.ObterUsuarioPorEmailAsync(email);
        }

        public async Task Inserir(RegistrarUsuarioViewModel registrarUsuario)
        {
            var usuarioFormatado = new Usuario()
            {
                Nome = registrarUsuario.Nome,
                Email = registrarUsuario.Email,
                SenhaHash = GerarHashSenha(registrarUsuario.Senha),
            };

            await _usuarioRepository.InserirAsync(usuarioFormatado);
        }

        public async Task<Usuario> LoginAsync(string email, string senha)
        {
            var usuario = new Usuario();
            usuario = _usuarioRepository.ObterUsuarioPorEmailAsync(email).Result;

            if (usuario == null || !VerificarHashSenha(senha, usuario.SenhaHash))
            {
                return null; // Autenticação falhou.
            }

            return usuario;
        }

        public Task Excluir(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
