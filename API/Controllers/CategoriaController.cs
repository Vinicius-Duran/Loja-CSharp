using Domain.Argumentos;
using Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly IServicoCategoria _servicoCategoria;

        public CategoriaController(IServicoCategoria servicoCategoria)
        {
            _servicoCategoria = servicoCategoria;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] CategoriaDTO categoriaDTO)
        {
            var categoriaAdicionada = _servicoCategoria.Adicionar(categoriaDTO);
            if (categoriaAdicionada == null)
            {
                return BadRequest();
            }
            return Ok(categoriaAdicionada);
        }

        [HttpPut]
        public IActionResult Editar([FromBody] CategoriaDTO categoriaDTO)
        {
            var categoriaEditada = _servicoCategoria.Editar(categoriaDTO);
            if (categoriaEditada == null)
            {
                return NotFound();
            }
            return Ok(categoriaEditada);
        }

        [HttpGet]
        public IEnumerable<CategoriaDTO> Listar()
        {
            return _servicoCategoria.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var categoria = _servicoCategoria.ObterPorId(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _servicoCategoria.Remover(id);
            return NoContent();
        }
    }
}
