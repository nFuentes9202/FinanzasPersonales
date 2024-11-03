using FinanzasPersonales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Infrastructure.Data.EF_Infrastructure
{
    public class FinanzasDbContext : DbContext
    {
        public FinanzasDbContext(DbContextOptions<FinanzasDbContext> options) : base(options)
        {
        }

        // DbSet para cada entidad
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración adicional (índices, relaciones, restricciones)
            modelBuilder.Entity<Cuenta>().HasKey(c => c.CuentaID);
            modelBuilder.Entity<Transaccion>().HasKey(t => t.TransaccionID);
            modelBuilder.Entity<Categoria>().HasKey(cat => cat.CategoriaID);
        }
    }
}
