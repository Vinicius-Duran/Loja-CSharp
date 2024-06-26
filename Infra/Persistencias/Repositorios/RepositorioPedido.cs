using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Zicard.API.Common.Persistencia.Repositorios.Base;

namespace Infra.Persistencias.Repositorios
{
    public class RepositorioPedido : RepositorioBase<Pedido, int>, IRepositorioPedido
    {
        protected readonly APIContexto _context;

        public RepositorioPedido(APIContexto context) : base(context)
        {
            _context = context;
        }

        public void Remover(int id)
        {
            var entity = _context.Set<Pedido>().Find(id);
            if (entity != null)
            {
                _context.Set<Pedido>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
