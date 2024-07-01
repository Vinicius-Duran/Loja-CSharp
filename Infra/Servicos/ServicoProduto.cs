using AutoMapper;
using Domain.Argumentos;
using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Servicos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using Zicard.API.Common.Recursos;
using System.Collections.Generic;
using Zicard.API.Common.Extensoes;
using Infra.Persistencias.Repositorios;

namespace Infra.Servicos
{
    public class ServicoProduto : Notifiable, IServicoProduto
    {
        private readonly IRepositorioProduto _repositorioProduto;
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IMapper _mapper;

        public ServicoProduto(IRepositorioProduto repositorioProduto,IRepositorioUsuario repositorioUsuario, IMapper mapper)
        {
            _repositorioProduto = repositorioProduto;
            _repositorioUsuario = repositorioUsuario;
            _mapper = mapper;
        }

        public ProdutoDTO Adicionar(ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null)
            {
                AddNotification("produtoDTO", Mensagens.X0_NAO_INFORMADO.ToFormat("produtoDTO"));
                return null;
            }

            var produto = new Produto(produtoDTO);
            if (IsInvalid())
            {
                return null;
            }

            _repositorioProduto.Adicionar(produto);
            return _mapper.Map<ProdutoDTO>(produto);
        }

        public ProdutoDTO Editar(ProdutoDTO produtoDTO)
        {
            var produto = _repositorioProduto.ObterPorId(produtoDTO.Id);
            if (produto == null)
            {
                AddNotification("produtoDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            produto.Atualizar(produtoDTO);
            if (IsInvalid())
            {
                return null;
            }

            var response = _repositorioProduto.Editar(produto).ToMap<Produto, ProdutoDTO>(_mapper);

            return response;
        }

        public IEnumerable<ProdutoDTO> Listar()
        {
            var produtos = _repositorioProduto.Listar();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public ProdutoDTO ObterPorId(int id)
        {
            var produto = _repositorioProduto.ObterPorId(id);
            if (produto == null)
            {
                AddNotification("produtoDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            return _mapper.Map<ProdutoDTO>(produto);
        }

        public void Remover(int id)
        {
            var produto = _repositorioProduto.ObterPorId(id);
            if (produto == null)
            {
                AddNotification("produtoDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return;
            }

            _repositorioProduto.Remover(id);
        }

        public CompraDTO Comprar(int produtoId, int usuarioId, int quantidade)
        {
            var produto = _repositorioProduto.ObterPorId(produtoId);
            if (produto == null)
            {
                AddNotification("Produto", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            var usuario = _repositorioUsuario.ObterPorId(usuarioId);
            if (usuario == null)
            {
                AddNotification("Usuario", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            if (produto.Estoque < quantidade)
            {
                AddNotification("Produto", Mensagens.ERRO_OPERACAO_NAO_REALIZADA);
                return null;
            }

            produto.AtualizarEstoque(produto.Estoque - quantidade);
            usuario.AdicionarPontos(produto.Pontos * quantidade);

            _repositorioProduto.Editar(produto);
            _repositorioUsuario.Editar(usuario);

            return new CompraDTO
            {
                ProdutoId = produto.Id,
                UsuarioId = usuario.Id,
                Quantidade = quantidade,
                PontosGanho = produto.Pontos * quantidade
            };
        }
    }
}