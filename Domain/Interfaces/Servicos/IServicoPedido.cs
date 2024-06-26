using Domain.Argumentos;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Servicos
{
    public interface IServicoPedido : INotifiable
    {
        PedidoDTO Adicionar(PedidoDTO pedidoDTO);
        PedidoDTO Editar(PedidoDTO pedidoDTO);
        IEnumerable<PedidoDTO> Listar();
        PedidoDTO ObterPorId(int id);
        void Remover(int id);
    }
}
