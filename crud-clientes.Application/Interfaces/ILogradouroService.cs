using crud_clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_clientes.Application.Interfaces
{
    public interface ILogradouroService
    {
        Task<IEnumerable<Logradouro>> ObterTodosLogradouros();
        Task<Logradouro> ObterLogradouroPorId(Guid id);
        Task CriarLogradouro(Logradouro Logradouro);
        Task AtualizarLogradouro(Logradouro Logradouro);
        Task DeletarLogradouro(Guid id, Guid logradouroId);
    }
}
