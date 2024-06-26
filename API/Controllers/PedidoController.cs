using Domain.Argumentos;
using Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidoController : ControllerBase
    {
        private readonly IServicoPedido _servicoPedido;

        public PedidoController(IServicoPedido servicoPedido)
        {
            _servicoPedido = servicoPedido;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] PedidoDTO pedidoDTO)
        {
            var pedidoAdicionado = _servicoPedido.Adicionar(pedidoDTO);
            if (pedidoAdicionado == null)
            {
                return BadRequest();
            }
            return Ok(pedidoAdicionado);
        }

        [HttpPut]
        public IActionResult Editar([FromBody] PedidoDTO pedidoDTO)
        {
            var pedidoEditado = _servicoPedido.Editar(pedidoDTO);
            if (pedidoEditado == null)
            {
                return NotFound();
            }
            return Ok(pedidoEditado);
        }

        [HttpGet]
        public IEnumerable<PedidoDTO> Listar()
        {
            return _servicoPedido.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var pedido = _servicoPedido.ObterPorId(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _servicoPedido.Remover(id);
            return NoContent();
        }
    }
}
