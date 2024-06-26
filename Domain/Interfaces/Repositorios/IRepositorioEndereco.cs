using Domain.Entidades;
using Zicard.API.Common.Interfaces.Repositorios.Base;

namespace Domain.Interfaces.Repositorios
{
    public interface IRepositorioEndereco : IRepositorioBase<Endereco, int>
    {
        void Remover(int id);
    }
}
