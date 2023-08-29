using crud_clientes.Domain.Entities;
using crud_clientes.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_clientes.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public ClienteRepository() { }

        public Task AtualizarAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task InserirAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
