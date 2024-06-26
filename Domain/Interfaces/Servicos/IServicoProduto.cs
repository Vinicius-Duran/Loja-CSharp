using Domain.Argumentos;
using prmToolkit.NotificationPattern;

namespace Domain.Interfaces.Servicos
{
    public interface IServicoProduto : INotifiable
    {
        ProdutoDTO Adicionar(ProdutoDTO produtoDTO);
        ProdutoDTO Editar(ProdutoDTO produtoDTO);
        IEnumerable<ProdutoDTO> Listar();
        ProdutoDTO ObterPorId(int id);
        void Remover(int id);
    }
}
