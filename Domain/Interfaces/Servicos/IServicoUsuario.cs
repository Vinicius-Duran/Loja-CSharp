using Domain.Argumentos;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Servicos
{
    public interface IServicoUsuario : INotifiable
    {
        UsuarioDTO Adicionar(UsuarioDTO usuarioDTO);
        UsuarioDTO Editar(UsuarioDTO usuarioDTO);
        IEnumerable<UsuarioDTO> Listar();
        UsuarioDTO ObterPorId(int id);
        void Remover(int id);
        string Autenticar(string email, string senha);
    }
}
