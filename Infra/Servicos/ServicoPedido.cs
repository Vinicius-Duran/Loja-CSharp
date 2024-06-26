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

namespace Infra.Servicos
{
    public class ServicoPedido : Notifiable, IServicoPedido
    {
        private readonly IRepositorioPedido _repositorioPedido;
        private readonly IMapper _mapper;

        public ServicoPedido(IRepositorioPedido repositorioPedido, IMapper mapper)
        {
            _repositorioPedido = repositorioPedido;
            _mapper = mapper;
        }

        public PedidoDTO Adicionar(PedidoDTO pedidoDTO)
        {
            if (pedidoDTO == null)
            {
                AddNotification("pedidoDTO", Mensagens.X0_NAO_INFORMADO.ToFormat("pedidoDTO"));
                return null;
            }

            var pedido = new Pedido(pedidoDTO);
            if (IsInvalid())
            {
                return null;
            }

            _repositorioPedido.Adicionar(pedido);
            return _mapper.Map<PedidoDTO>(pedido);
        }

        public PedidoDTO Editar(PedidoDTO pedidoDTO)
        {
            var pedido = _repositorioPedido.ObterPorId(pedidoDTO.Id);
            if (pedido == null)
            {
                AddNotification("pedidoDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            pedido.Atualizar(pedidoDTO);
            if (IsInvalid())
            {
                return null;
            }

            var response = _repositorioPedido.Editar(pedido).ToMap<Pedido, PedidoDTO>(_mapper);

            return response;
        }

        public IEnumerable<PedidoDTO> Listar()
        {
            var pedidos = _repositorioPedido.Listar();
            return _mapper.Map<IEnumerable<PedidoDTO>>(pedidos);
        }

        public PedidoDTO ObterPorId(int id)
        {
            var pedido = _repositorioPedido.ObterPorId(id);
            if (pedido == null)
            {
                AddNotification("pedidoDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            return _mapper.Map<PedidoDTO>(pedido);
        }

        public void Remover(int id)
        {
            var pedido = _repositorioPedido.ObterPorId(id);
            if (pedido == null)
            {
                AddNotification("pedidoDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return;
            }

            _repositorioPedido.Remover(id);
        }
    }
}