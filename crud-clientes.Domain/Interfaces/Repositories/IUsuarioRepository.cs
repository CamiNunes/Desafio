using crud_clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_clientes.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterUsuarioPorEmailAsync(string email);
        Task InserirAsync(Usuario usuario);
        Task ExcluirAsync(Guid id);
    }
}
