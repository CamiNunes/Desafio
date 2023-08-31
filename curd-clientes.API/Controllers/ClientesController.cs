using crud_clientes.Application.Interfaces;
using crud_clientes.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace curd_clientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var clientes = _clienteService.ObterTodosClientes();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var cliente = _clienteService.ObterClientePorId(id);
                if (cliente == null)
                    return NotFound();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                var novoCliente = _clienteService.CriarCliente(cliente);
                if (novoCliente.Exception == null)
                {
                    //return CreatedAtAction(nameof(Post), new { id = cliente.ClienteId }, cliente);
                    return Ok(new { message = "Cliente cadastrado com sucesso!" });
                }

                return Ok(new { message = novoCliente.Exception.InnerException.Message });
                

            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Cliente cliente)
        {
            try
            {
                _clienteService.AtualizarCliente(cliente);
                return Ok("Cliente atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _clienteService.DeletarCliente(id);
                return Ok("Cliente deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}
