using Domain.Argumentos;
using Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IServicoUsuario _servicoUsuario;

        public UsuarioController(IServicoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] UsuarioDTO usuarioDTO)
        {
            var usuarioAdicionado = _servicoUsuario.Adicionar(usuarioDTO);
            if (usuarioAdicionado == null)
            {
                return BadRequest();
            }
            return Ok(usuarioAdicionado);
        }

        [HttpPut]
        public IActionResult Editar([FromBody] UsuarioDTO usuarioDTO)
        {
            var usuarioEditado = _servicoUsuario.Editar(usuarioDTO);
            if (usuarioEditado == null)
            {
                return NotFound();
            }
            return Ok(usuarioEditado);
        }

        [HttpGet]
        public IEnumerable<UsuarioDTO> Listar()
        {
            return _servicoUsuario.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var usuario = _servicoUsuario.ObterPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _servicoUsuario.Remover(id);
            return NoContent();
        }
    }
}
