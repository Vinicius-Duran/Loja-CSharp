using Domain.Entidades;
using Zicard.API.Common.Argumentos.Base;

namespace Domain.Argumentos
{
    public class PedidoDTO : ArgumentoBase
    {
        public int CodigoPedido { get;  set; }

        public int UsuarioId { get;  set; }
        public int ProdutoId { get;  set; }

        public virtual UsuarioDTO UsuarioDTO { get;  set; }
        public virtual ProdutoDTO ProdutoDTO { get;  set; }
    }
}
