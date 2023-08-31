using crud_clientes.Application.Interfaces;
using crud_clientes.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace curd_clientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        //private readonly IAuthService _authService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
            //_authService = authService;
        }

        [HttpGet]
        public IActionResult Get(string email)
        {
            try
            {
                var usuarios = _usuarioService.ObterUsuarioPorEmail(email);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult Register(RegistrarUsuarioViewModel registrarUsuario)
        {
            // Valide os dados do usuário, faça outras verificações necessárias.

            var usuarioExistente = _usuarioService.ObterUsuarioPorEmail(registrarUsuario.Email);
            if (usuarioExistente.Result != null)
            {
                //throw new Exception("Usuário com o email " + registrarUsuario.Email + " já existe.");
                return Ok(new { message = "Usuário com o email " + registrarUsuario.Email + " já existe." });
            }

            try
            {
                var usuarioCriado = _usuarioService.Inserir(registrarUsuario);
                return Ok(new { message = "Usuário registrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao registrar o usuário: " + ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var usuario = await _usuarioService.LoginAsync(login.Email, login.Senha);
            if (usuario == null)
            {
                return Unauthorized("Email ou senha inválidos."); // Autenticação falhou.
            }

            var token = "";
            //var token = _authService.GerarJwtToken(usuario.Email, usuario.UsuarioId);
            return Ok(new { token });
        }
    }
}
