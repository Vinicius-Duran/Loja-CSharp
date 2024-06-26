using Domain.Argumentos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using Zicard.API.Common.Entidades.Base;
using Zicard.API.Common.Recursos;

namespace Domain.Entidades
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public int Estoque { get; private set; }


        public int CategoriaId { get; private set; }
        public virtual Categoria Categoria { get; private set; }

        public virtual ICollection<Pedido> Pedido { get; private set; }

        public Produto() { }

        public Produto(ProdutoDTO produtoDTO) 
        {
            Nome = produtoDTO.Nome;
            Codigo = produtoDTO.Codigo;
            Descricao = produtoDTO.Descricao;
            Valor = produtoDTO.Valor;
            Estoque = produtoDTO.Estoque;
            CategoriaId = produtoDTO.CategoriaId;

            new AddNotifications<Produto>(this).IfNullOrEmpty(x => x.Nome, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("nome"));
            new AddNotifications<Produto>(this).IfNullOrEmpty(x => x.Codigo, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("codigo"));
            new AddNotifications<Produto>(this).IfNullOrEmpty(x => x.Descricao, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("descricao"));
            new AddNotifications<Produto>(this).IfEqualsZero(x => x.Valor, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("valor"));
            new AddNotifications<Produto>(this).IfEqualsZero(x => x.Estoque, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("estoque"));
            new AddNotifications<Produto>(this).IfEqualsZero(x => x.CategoriaId, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("categoriaid"));
        }

        public void Atualizar(ProdutoDTO produtoDTO)
        {
            Nome = produtoDTO.Nome;
            Codigo = produtoDTO.Codigo;
            Descricao = produtoDTO.Descricao;
            Valor = produtoDTO.Valor;
            Estoque = produtoDTO.Estoque;
            CategoriaId = produtoDTO.CategoriaId;


            new AddNotifications<Produto>(this).IfNullOrEmpty(x => x.Nome, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("nome"));
            new AddNotifications<Produto>(this).IfNullOrEmpty(x => x.Codigo, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("codigo"));
            new AddNotifications<Produto>(this).IfNullOrEmpty(x => x.Descricao, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("descricao"));
            new AddNotifications<Produto>(this).IfEqualsZero(x => x.Valor, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("valor"));
            new AddNotifications<Produto>(this).IfEqualsZero(x => x.Estoque, Mensagens.O_CAMPO_X0_E_OBRIGATORIO.ToFormat("estoque"));
        }

    }
}
