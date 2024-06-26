using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Zicard.API.Common.Persistencia.Repositorios.Base;

namespace Infra.Persistencias.Repositorios
{
    public class RepositorioProduto : RepositorioBase<Produto, int>, IRepositorioProduto
    {
        protected readonly APIContexto _context;

        public RepositorioProduto(APIContexto context) : base(context)
        {
            _context = context;
        }

        public void Remover(int id)
        {
            var entity = _context.Set<Produto>().Find(id);
            if (entity != null)
            {
                _context.Set<Produto>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
