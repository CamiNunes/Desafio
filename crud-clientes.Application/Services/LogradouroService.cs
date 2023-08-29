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
    public class LogradouroService : ILogradouroService
    {
        private readonly ILogradouroRepository _logradouroRepository;

        public LogradouroService(ILogradouroRepository logradouroRepository)
        {
            _logradouroRepository = logradouroRepository;
        }

        public Task AtualizarLogradouro(Logradouro Logradouro)
        {
            throw new NotImplementedException();
        }

        public Task CriarLogradouro(Logradouro Logradouro)
        {
            throw new NotImplementedException();
        }

        public Task DeletarLogradouro(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Logradouro> ObterLogradouroPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Logradouro>> ObterTodosLogradouros()
        {
            throw new NotImplementedException();
        }
    }
}
