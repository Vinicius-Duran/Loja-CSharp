using Domain.Argumentos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using Zicard.API.Common.Entidades.Base;
using Zicard.API.Common.Recursos;

namespace Domain.Entidades
{
    public class Pedido : EntidadeBase
    {
        public int CodigoPedido { get; private set; }

        public int UsuarioId { get; private set; }
        public int ProdutoId { get; private set; }

        public virtual Usuario Usuario { get; private set; }
        public virtual Produto Produto { get; private set; }

        public Pedido() { }

        public Pedido(PedidoDTO pedidoDTO) 
        {
            CodigoPedido = pedidoDTO.CodigoPedido;
            UsuarioId = pedidoDTO.UsuarioId;
            ProdutoId = pedidoDTO.ProdutoId;

            new AddNotifications<Pedido>(this).IfEqualsZero(x => x.CodigoPedido, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("codigopedido"));
            new AddNotifications<Pedido>(this).IfEqualsZero(x => x.UsuarioId, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("usuarioid"));
            new AddNotifications<Pedido>(this).IfEqualsZero(x => x.ProdutoId, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("produtoid"));
        }

        public void Atualizar(PedidoDTO pedidoDTO)
        {
            CodigoPedido = pedidoDTO.CodigoPedido;
            UsuarioId = pedidoDTO.UsuarioId;
            ProdutoId = pedidoDTO.ProdutoId;

            new AddNotifications<Pedido>(this).IfEqualsZero(x => x.CodigoPedido, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("codigopedido"));
            new AddNotifications<Pedido>(this).IfEqualsZero(x => x.UsuarioId, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("usuarioid"));
            new AddNotifications<Pedido>(this).IfEqualsZero(x => x.ProdutoId, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("produtoid"));
        }
    }
}
