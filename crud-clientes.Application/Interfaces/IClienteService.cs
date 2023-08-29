using crud_clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_clientes.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ObterTodosClientes();
        Task<Cliente> ObterClientePorId(Guid id);
        Task CriarCliente(Cliente cliente);
        Task AtualizarCliente(Cliente cliente);
        Task DeletarCliente(Guid id);
    }
}
