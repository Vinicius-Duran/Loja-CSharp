using Domain.Argumentos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using Zicard.API.Common.Entidades.Base;
using Zicard.API.Common.Recursos;

namespace Domain.Entidades
{
    public class Categoria : EntidadeBase
    {
        public string Nome { get; private set; }

        public virtual ICollection<Produto> Produto { get; private set; }

        public Categoria() { }

        public Categoria(CategoriaDTO categoriaDTO) 
        {
            Nome = categoriaDTO.Nome;

            new AddNotifications<Categoria>(this).IfNullOrEmpty(x => x.Nome, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("nome"));
        }

        public void Atualizar(CategoriaDTO categoriaDTO)
        {
            Nome = categoriaDTO.Nome;

            new AddNotifications<Categoria>(this).IfNullOrEmpty(x => x.Nome, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("nome"));
        }
    }
}
