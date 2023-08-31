using crud_clientes.Domain.Entities;
using crud_clientes.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_clientes.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> ObterUsuarioPorEmail(string email);
        Task Inserir(RegistrarUsuarioViewModel usuario);
        Task Excluir(Guid id);
        Task<Usuario> LoginAsync(string email, string senha);
    }
}
