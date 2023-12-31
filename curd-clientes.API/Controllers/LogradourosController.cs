﻿using crud_clientes.Application.Interfaces;
using crud_clientes.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace curd_clientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogradourosController : ControllerBase
    {
        private readonly ILogradouroService _logradouroService;

        public LogradourosController(ILogradouroService logradouroService)
        {
            _logradouroService = logradouroService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var logradouros = _logradouroService.ObterTodosLogradouros(id);
                return Ok(logradouros);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpGet("{id}/{logradouroId}")]
        public IActionResult Get(Guid id, Guid logradouroId)
        {
            try
            {
                var logradouro = _logradouroService.ObterLogradouroPorId(id, logradouroId);
                if (logradouro == null)
                    return NotFound();

                return Ok(logradouro);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody] Logradouro logradouro)
        {
            try
            {
                _logradouroService.CriarLogradouro(logradouro);
                return CreatedAtAction(nameof(Get), new { id = logradouro.LogradouroId }, logradouro);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpPut("{id}/{logradouroId}")]
        public IActionResult Put(Guid id, Guid logradouroId, [FromBody] Logradouro logradouro)
        {
            try
            {
                logradouro.ClienteId = id;
                logradouro.LogradouroId = logradouroId;
                _logradouroService.AtualizarLogradouro(logradouro);
                return Ok("Endereço atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpDelete("{id}/{logradouroId}")]
        public IActionResult Delete(Guid id, Guid logradouroId)
        {
            try
            {
                _logradouroService.DeletarLogradouro(id, logradouroId);
                return Ok("Endereço deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}
