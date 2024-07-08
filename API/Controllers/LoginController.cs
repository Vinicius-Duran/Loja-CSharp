using Domain.Argumentos;
using Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Zicard.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IServicoUsuario _servicoUsuario;
        private readonly IConfiguration _configuration;

        public AuthController(IServicoUsuario servicoUsuario, IConfiguration configuration)
        {
            _servicoUsuario = servicoUsuario;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Senha))
            {
                return BadRequest("Informe o email e a senha.");
            }

            var token = _servicoUsuario.Autenticar(model.Email, model.Senha);

            if (token == null)
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }

            return Ok(new { Token = token });
        }
    }
}
