using Domain.Entidades;
using Zicard.API.Common.Interfaces.Repositorios.Base;

namespace Domain.Interfaces.Repositorios
{
    public interface IRepositorioCategoria : IRepositorioBase<Categoria, int>
    {
        void Remover(int id);
    }
}
