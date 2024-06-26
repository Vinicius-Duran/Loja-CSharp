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
    public class ServicoEndereco : Notifiable, IServicoEndereco
    {
        private readonly IRepositorioEndereco _repositorioEndereco;
        private readonly IMapper _mapper;

        public ServicoEndereco(IRepositorioEndereco repositorioEndereco, IMapper mapper)
        {
            _repositorioEndereco = repositorioEndereco;
            _mapper = mapper;
        }

        public EnderecoDTO Adicionar(EnderecoDTO enderecoDTO)
        {
            if (enderecoDTO == null)
            {
                AddNotification("enderecoDTO", Mensagens.X0_NAO_INFORMADO.ToFormat("enderecoDTO"));
                return null;
            }

            var endereco = new Endereco(enderecoDTO);
            if (IsInvalid())
            {
                return null;
            }

            _repositorioEndereco.Adicionar(endereco);
            return _mapper.Map<EnderecoDTO>(endereco);
        }

        public EnderecoDTO Editar(EnderecoDTO enderecoDTO)
        {
            var endereco = _repositorioEndereco.ObterPorId(enderecoDTO.Id);
            if (endereco == null)
            {
                AddNotification("enderecoDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            endereco.Atualizar(enderecoDTO);
            if (IsInvalid())
            {
                return null;
            }

            _repositorioEndereco.Editar(endereco);
            return _mapper.Map<EnderecoDTO>(endereco);
        }

        public IEnumerable<EnderecoDTO> Listar()
        {
            var enderecos = _repositorioEndereco.Listar();
            return _mapper.Map<IEnumerable<EnderecoDTO>>(enderecos);
        }

        public EnderecoDTO ObterPorId(int id)
        {
            var endereco = _repositorioEndereco.ObterPorId(id);
            if (endereco == null)
            {
                AddNotification("enderecoDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            return _mapper.Map<EnderecoDTO>(endereco);
        }

        public void Remover(int id)
        {
            var endereco = _repositorioEndereco.ObterPorId(id);
            if (endereco == null)
            {
                AddNotification("enderecoDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return;
            }

            _repositorioEndereco.Remover(id);
        }
    }
}