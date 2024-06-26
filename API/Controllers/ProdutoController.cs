using Domain.Argumentos;
using Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IServicoProduto _servicoProduto;

        public ProdutoController(IServicoProduto servicoProduto)
        {
            _servicoProduto = servicoProduto;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] ProdutoDTO produtoDTO)
        {
            var produtoAdicionado = _servicoProduto.Adicionar(produtoDTO);
            if (produtoAdicionado == null)
            {
                return BadRequest();
            }
            return Ok(produtoAdicionado);
        }

        [HttpPut]
        public IActionResult Editar([FromBody] ProdutoDTO produtoDTO)
        {
            var produtoEditado = _servicoProduto.Editar(produtoDTO);
            if (produtoEditado == null)
            {
                return NotFound();
            }
            return Ok(produtoEditado);
        }

        [HttpGet]
        public IEnumerable<ProdutoDTO> Listar()
        {
            return _servicoProduto.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var produto = _servicoProduto.ObterPorId(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _servicoProduto.Remover(id);
            return NoContent();
        }
    }
}
