using AutoMapper;
using Domain.Argumentos;
using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Servicos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using Sentry.Protocol;
using Zicard.API.Common.Extensoes;
using Zicard.API.Common.Recursos;

namespace Infra.Servicos
{
    public class ServicoUsuario : Notifiable, IServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IMapper _mapper;

        public ServicoUsuario(IRepositorioUsuario repositorioUsuario, IMapper mapper)
        {
            _repositorioUsuario = repositorioUsuario;
            _mapper = mapper;
        }

        public UsuarioDTO Adicionar(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                AddNotification("usuarioDTO", Mensagens.X0_NAO_INFORMADO.ToFormat("usuarioDTO"));
                return null;
            }

            var usuario = new Usuario(usuarioDTO);
            _repositorioUsuario.Adicionar(usuario);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public UsuarioDTO Editar(UsuarioDTO usuarioDTO)
        {
            var usuario = _repositorioUsuario.ObterPorId(usuarioDTO.Id);
            if (usuario == null)
            {
                AddNotification("usuarioDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            usuario.Atualizar(usuarioDTO);
            var response = _repositorioUsuario.Editar(usuario).ToMap<Usuario, UsuarioDTO>(_mapper);

            return response;
        }

        public IEnumerable<UsuarioDTO> Listar()
        {
            var usuarios = _repositorioUsuario.Listar();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }

        public UsuarioDTO ObterPorId(int id)
        {
            var usuario = _repositorioUsuario.ObterPorId(id);
            if (usuario == null)
            {
                AddNotification("usuarioDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public void Remover(int id)
        {
            var usuario = _repositorioUsuario.ObterPorId(id);
            if (usuario == null)
            {
                AddNotification("usuarioDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return;
            }

            _repositorioUsuario.Remover(id);
        }
    }
}