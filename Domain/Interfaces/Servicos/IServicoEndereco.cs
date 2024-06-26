using Domain.Argumentos;
using prmToolkit.NotificationPattern;

namespace Domain.Interfaces.Servicos
{
    public interface IServicoEndereco : INotifiable
    {
        EnderecoDTO Adicionar(EnderecoDTO enderecoDTO);
        EnderecoDTO Editar(EnderecoDTO enderecoDTO);
        IEnumerable<EnderecoDTO> Listar();
        EnderecoDTO ObterPorId(int id);
        void Remover(int id);
    }
}
