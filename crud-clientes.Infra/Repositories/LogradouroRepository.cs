using crud_clientes.Domain.Entities;
using crud_clientes.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_clientes.Infra.Repositories
{
    public class LogradouroRepository : ILogradouroRepository
    {
        public Task AtualizarAsync(Logradouro logradouro)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task InserirAsync(Logradouro logradouro)
        {
            throw new NotImplementedException();
        }

        public Task<Logradouro> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Logradouro>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
