using Microsoft.EntityFrameworkCore;
using PruebaTalycapglobal.Models;

namespace PruebaTalycapglobal.DataContext
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(cliente =>
            {
                cliente.HasKey(c => c.Id);
                cliente.Property(c => c.Identificacion).IsRequired().HasMaxLength(10);
                cliente.Property(c => c.TipoDocumento).IsRequired();
                cliente.Property(c => c.Nombres).IsRequired().HasMaxLength(50);
                cliente.Property(c => c.Apellidos).IsRequired().HasMaxLength(50);
                cliente.Property(c => c.Direccion).IsRequired().HasMaxLength(200);
                cliente.Property(c => c.Telefono).HasMaxLength(20);
                cliente.Property(c => c.Email).IsRequired().HasMaxLength(100);
            });

        }

    }
}
