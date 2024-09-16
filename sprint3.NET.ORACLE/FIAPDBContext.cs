using Microsoft.EntityFrameworkCore;
using sprint3.NET.Database.Mapping;
using sprint3.NET.Database.Models;

namespace sprint3.NET.Database.Persistencia
{
    public class FIAPDbContext : DbContext
    {
        public FIAPDbContext(DbContextOptions<FIAPDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Agricultor> Agricultor { get; set; }
        public DbSet<Fazenda> Fazenda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new AgricultorMapping());
            modelBuilder.ApplyConfiguration(new FazendaMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
