using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Zicard.API.Common.Persistencia.Repositorios.Base;

namespace Infra.Persistencias.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Usuario, int>, IRepositorioUsuario
    {
        protected readonly APIContexto _context;

        public RepositorioUsuario(APIContexto context) : base(context)
        {
            _context = context;
        }

        public void Remover(int id)
        {
            var entity = _context.Set<Usuario>().Find(id);
            if (entity != null)
            {
                _context.Set<Usuario>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
