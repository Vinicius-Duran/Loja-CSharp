using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;

namespace Infra.Persistencias
{
    public class APIContexto : DbContext
    {
        public APIContexto(DbContextOptions<APIContexto> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Usuario)
                .WithMany(u => u.Enderecos)
                .HasForeignKey(e => e.UsuarioId);

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Produto)
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<Pedido>()
                .HasOne(e => e.Usuario)
                .WithMany(u => u.Pedido)
                .HasForeignKey(e => e.UsuarioId);

            modelBuilder.Entity<Pedido>()
                .HasOne(e => e.Produto)
                .WithMany(u => u.Pedido)
                .HasForeignKey(e => e.ProdutoId);
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataInclusao").CurrentValue = DateTime.Now;
                }

                if (entry.State != EntityState.Modified) continue;
                entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
            }
        }
    }
}
