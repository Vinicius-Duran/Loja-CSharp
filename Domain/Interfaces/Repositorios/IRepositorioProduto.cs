using Domain.Entidades;
using Zicard.API.Common.Interfaces.Repositorios.Base;

namespace Domain.Interfaces.Repositorios
{
    public interface IRepositorioProduto : IRepositorioBase<Produto, int>
    {
        void Remover(int id);
    }
}
