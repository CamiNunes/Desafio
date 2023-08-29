using crud_clientes.Application.Interfaces;
using crud_clientes.Domain.Entities;
using crud_clientes.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_clientes.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task AtualizarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task CriarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task DeletarCliente(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> ObterClientePorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> ObterTodosClientes()
        {
            throw new NotImplementedException();
        }
    }
}
