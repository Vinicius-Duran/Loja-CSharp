using AutoMapper;
using Domain.Argumentos;
using Domain.Entidades;

namespace Infra.Persistencias
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<Pedido, PedidoDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
