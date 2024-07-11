using Domain.Entidades;
using Zicard.API.Common.Argumentos.Base;

namespace Domain.Argumentos
{
    public class UsuarioDTO : ArgumentoBase
    {
        public string Nome { get;  set; }
        public string Email { get;  set; }
        public string Senha { get;  set; }
        public string Cpf { get;  set; }
        public string Celular { get;  set; }
        public int Pontos { get;  set; }

        public virtual ICollection<EnderecoDTO> Enderecos { get;  set; }
        public virtual ICollection<PedidoDTO> Pedido { get;  set; }
    }
}
