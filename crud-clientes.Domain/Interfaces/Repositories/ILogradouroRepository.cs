using crud_clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_clientes.Domain.Interfaces.Repositories
{
    public interface ILogradouroRepository
    {
        Task<IEnumerable<Logradouro>> ObterTodosLogradourosAsync(Guid id);
        Task<Logradouro> ObterPorIdAsync(Guid id, Guid logradouroId);
        Task InserirAsync(Logradouro logradouro);
        Task AtualizarAsync(Logradouro logradouro);
        Task ExcluirAsync(Guid id, Guid logradouroId);
    }
}
