using Domain.Entidades;
using Zicard.API.Common.Interfaces.Repositorios.Base;

namespace Domain.Interfaces.Repositorios
{
    public interface IRepositorioPedido : IRepositorioBase<Pedido, int>
    {
        void Remover(int id);
    }
}
