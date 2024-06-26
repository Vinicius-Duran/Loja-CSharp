using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infra.Persistencias
{
    public class APIContexto : DbContext
    {
        public APIContexto(DbContextOptions<APIContexto> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
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
    }
}
