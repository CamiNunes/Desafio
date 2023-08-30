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

        public async Task<IEnumerable<Cliente>> ObterTodosClientes()
        {
            return await _clienteRepository.ObterTodosAsync();
        }

        public async Task<Cliente> ObterClientePorId(Guid id)
        {
            return await _clienteRepository.ObterPorIdAsync(id);
        }

        public async Task CriarCliente(Cliente cliente)
        {
            await _clienteRepository.InserirAsync(cliente);
        }

        public async Task AtualizarCliente(Cliente cliente)
        {
            await _clienteRepository.AtualizarAsync(cliente);
        }

        public async Task DeletarCliente(Guid id)
        {
            await _clienteRepository.ExcluirAsync(id);
        }

    }
}
