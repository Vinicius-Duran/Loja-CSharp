using Domain.Argumentos;
using Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/enderecos")]
    public class EnderecoController : ControllerBase
    {
        private readonly IServicoEndereco _servicoEndereco;

        public EnderecoController(IServicoEndereco servicoEndereco)
        {
            _servicoEndereco = servicoEndereco;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] EnderecoDTO enderecoDTO)
        {
            var enderecoAdicionado = _servicoEndereco.Adicionar(enderecoDTO);
            if (enderecoAdicionado == null)
            {
                return BadRequest();
            }
            return Ok(enderecoAdicionado);
        }

        [HttpPut]
        public IActionResult Editar([FromBody] EnderecoDTO enderecoDTO)
        {
            var enderecoEditado = _servicoEndereco.Editar(enderecoDTO);
            if (enderecoEditado == null)
            {
                return NotFound();
            }
            return Ok(enderecoEditado);
        }

        [HttpGet]
        public IEnumerable<EnderecoDTO> Listar()
        {
            return _servicoEndereco.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var endereco = _servicoEndereco.ObterPorId(id);
            if (endereco == null)
            {
                return NotFound();
            }
            return Ok(endereco);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _servicoEndereco.Remover(id);
            return NoContent();
        }
    }
}
