using Domain.Argumentos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using Zicard.API.Common.Entidades.Base;
using Zicard.API.Common.Recursos;

namespace Domain.Entidades
{
    public class Endereco : EntidadeBase
    {
        public int Cep { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }

        public int UsuarioId { get; private set; }
        public virtual Usuario Usuario { get; private set; }

        public Endereco() { }

        public Endereco(EnderecoDTO enderecoDTO) 
        {
            Cep = enderecoDTO.Cep;  
            Estado = enderecoDTO.Estado;
            Cidade = enderecoDTO.Cidade;
            Bairro = enderecoDTO.Bairro;
            Rua = enderecoDTO.Rua;
            Numero = enderecoDTO.Numero;
            UsuarioId = enderecoDTO.UsuarioId;


            new AddNotifications<Endereco>(this).IfEqualsZero(x => x.Cep, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("cep"));
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Estado, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("estado"));
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Cidade, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("cidade"));
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Bairro, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("bairro"));
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Rua, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("rua"));
            new AddNotifications<Endereco>(this).IfEqualsZero(x => x.Numero, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("numero"));
            new AddNotifications<Endereco>(this).IfEqualsZero(x => x.UsuarioId, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("usuarioid"));
        }

        public void Atualizar(EnderecoDTO enderecoDTO)
        {
            Cep = enderecoDTO.Cep;
            Estado = enderecoDTO.Estado;
            Cidade = enderecoDTO.Cidade;
            Bairro = enderecoDTO.Bairro;
            Rua = enderecoDTO.Rua;
            Numero = enderecoDTO.Numero;
            UsuarioId = enderecoDTO.UsuarioId;

            new AddNotifications<Endereco>(this).IfEqualsZero(x => x.Cep, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("cep"));
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Estado, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("estado"));
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Cidade, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("cidade"));
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Bairro, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("bairro"));
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Rua, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("rua"));
            new AddNotifications<Endereco>(this).IfEqualsZero(x => x.Numero, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("numero"));
            new AddNotifications<Endereco>(this).IfEqualsZero(x => x.UsuarioId, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("usuarioid"));
        }
    }
}
