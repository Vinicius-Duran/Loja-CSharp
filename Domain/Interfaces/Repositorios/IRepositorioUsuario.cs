using Domain.Entidades;
using Zicard.API.Common.Interfaces.Repositorios.Base;

namespace Domain.Interfaces.Repositorios
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario, int>
    {
        void Remover(int id);
        Usuario ObterPorEmailSenha(string email, string senha);
    }
}
