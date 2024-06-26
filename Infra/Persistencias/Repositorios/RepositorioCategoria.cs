using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Zicard.API.Common.Persistencia.Repositorios.Base;

namespace Infra.Persistencias.Repositorios
{
    public class RepositorioCategoria : RepositorioBase<Categoria, int>, IRepositorioCategoria
    {
        protected readonly APIContexto _context;

        public RepositorioCategoria(APIContexto context) : base(context)
        {
            _context = context;
        }

        public void Remover(int id)
        {
            var entity = _context.Set<Categoria>().Find(id);
            if (entity != null)
            {
                _context.Set<Categoria>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
