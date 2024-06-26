using Zicard.API.Common.Argumentos.Base;

namespace Domain.Argumentos
{
    public class EnderecoDTO : ArgumentoBase
    {
        public int Cep { get;  set; }
        public string Estado { get;  set; }
        public string Cidade { get;  set; }
        public string Bairro { get;  set; }
        public string Rua { get;  set; }
        public int Numero { get;  set; }

        public int UsuarioId { get;  set; }
        public virtual UsuarioDTO UsuarioDTO { get;  set; }
    }
}
