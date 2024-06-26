using Domain.Argumentos;
using prmToolkit.NotificationPattern;

namespace Domain.Interfaces.Servicos
{
    public interface IServicoCategoria : INotifiable
    {
        CategoriaDTO Adicionar(CategoriaDTO categoriaDTO);
        CategoriaDTO Editar(CategoriaDTO categoriaDTO);
        IEnumerable<CategoriaDTO> Listar();
        CategoriaDTO ObterPorId(int id);
        void Remover(int id);
    }
}
