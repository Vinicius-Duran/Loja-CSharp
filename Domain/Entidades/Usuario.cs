using Domain.Argumentos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using Zicard.API.Common.Entidades.Base;
using Zicard.API.Common.Extensoes;
using Zicard.API.Common.Recursos;

namespace Domain.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Cpf { get; private set; }
        public string Celular { get; private set; }

        public virtual ICollection<Endereco> Enderecos { get; private set; }
        public virtual ICollection<Pedido> Pedido { get; private set; }

        public Usuario() { }

        public Usuario(UsuarioDTO usuarioDTO)
        {
            Nome = usuarioDTO.Nome;
            Email = usuarioDTO.Email;
            Senha = usuarioDTO.Senha;
            Cpf = usuarioDTO.Cpf;
            Celular = usuarioDTO.Celular;

            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Nome, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("nome"));
            new AddNotifications<Usuario>(this).IfFalse(Cpf.IsCpf(), "Documento", Mensagens.CPF_INVALIDO);
            new AddNotifications<Usuario>(this).IfTrue(string.IsNullOrEmpty(Email) || !Email.IsEmailValido(), "E-mail", Mensagens.EMAIL_INVALIDO.ToFormat("e-mail"));
            new AddNotifications<Usuario>(this).IfTrue(string.IsNullOrEmpty(Celular) || !Celular.IsNumero() || Celular.Length < 10, "Celular", Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("celular"));
            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Senha, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("senha"));
        }

        public void Atualizar(UsuarioDTO usuarioDTO)
        {
            Nome = usuarioDTO.Nome;
            Email = usuarioDTO.Email;
            Senha = usuarioDTO.Senha;
            Cpf = usuarioDTO.Cpf;
            Celular = usuarioDTO.Celular;

            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Nome, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("nome"));
            new AddNotifications<Usuario>(this).IfFalse(Cpf.IsCpf(), "Documento", Mensagens.CPF_INVALIDO);
            new AddNotifications<Usuario>(this).IfTrue(string.IsNullOrEmpty(Email) || !Email.IsEmailValido(), "E-mail", Mensagens.EMAIL_INVALIDO.ToFormat("e-mail"));
            new AddNotifications<Usuario>(this).IfTrue(string.IsNullOrEmpty(Celular) || !Celular.IsNumero() || Celular.Length < 10, "Celular", Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("celular"));
            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Senha, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("senha"));
        }

    }
}