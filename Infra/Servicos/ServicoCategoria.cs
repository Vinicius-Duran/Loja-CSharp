using AutoMapper;
using Domain.Argumentos;
using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Servicos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using Zicard.API.Common.Extensoes;
using Zicard.API.Common.Recursos;

namespace Infra.Servicos
{
    public class ServicoCategoria : Notifiable, IServicoCategoria
    {
        private readonly IRepositorioCategoria _repositorioCategoria;
        private readonly IMapper _mapper;

        public ServicoCategoria(IRepositorioCategoria repositorioCategoria, IMapper mapper)
        {
            _repositorioCategoria = repositorioCategoria;
            _mapper = mapper;
        }

        public CategoriaDTO Adicionar(CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
            {
                AddNotification("categoriaDTO", Mensagens.X0_NAO_INFORMADO.ToFormat("categoriaDTO"));
                return null;
            }

            var categoria = new Categoria(categoriaDTO);
            if (IsInvalid())
            {
                return null;
            }

            _repositorioCategoria.Adicionar(categoria);
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public CategoriaDTO Editar(CategoriaDTO categoriaDTO)
        {
            var categoria = _repositorioCategoria.ObterPorId(categoriaDTO.Id);
            if (categoria == null)
            {
                AddNotification("categoriaDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            categoria = new Categoria(categoriaDTO); 
            if (IsInvalid())
            {
                return null;
            }

            _repositorioCategoria.Editar(categoria);
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public IEnumerable<CategoriaDTO> Listar()
        {
            var categorias = _repositorioCategoria.Listar();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
        }

        public CategoriaDTO ObterPorId(int id)
        {
            var categoria = _repositorioCategoria.ObterPorId(id);
            if (categoria == null)
            {
                AddNotification("categoriaDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public void Remover(int id)
        {
            var categoria = _repositorioCategoria.ObterPorId(id);
            if (categoria == null)
            {
                AddNotification("categoriaDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return;
            }

            _repositorioCategoria.Remover(id);
        }
    }
}