using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Zicard.API.Common.Persistencia.Repositorios.Base;

namespace Infra.Persistencias.Repositorios
{
    public class RepositorioEndereco : RepositorioBase<Endereco, int>, IRepositorioEndereco
    {
        protected readonly APIContexto _context;

        public RepositorioEndereco(APIContexto context) : base(context)
        {
            _context = context;
        }

        public void Remover(int id)
        {
            var entity = _context.Set<Endereco>().Find(id);
            if (entity != null)
            {
                _context.Set<Endereco>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
