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

        public async Task<IEnumerable<Logradouro>> ObterTodosLogradouros()
        {
            return await _logradouroRepository.ObterTodosAsync();
        }

        public async Task<Logradouro> ObterLogradouroPorId(Guid id)
        {
            return await _logradouroRepository.ObterPorIdAsync(id);
        }

        public async Task AtualizarLogradouro(Logradouro Logradouro)
        {
            await _logradouroRepository.AtualizarAsync(Logradouro);
        }

        public async Task CriarLogradouro(Logradouro Logradouro)
        {
            await _logradouroRepository.InserirAsync(Logradouro);
        }

        public async Task DeletarLogradouro(Guid id, Guid logradouroId)
        {
            await _logradouroRepository.ExcluirAsync(id, logradouroId);
        }
    }
}
