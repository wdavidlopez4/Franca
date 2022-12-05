using Franca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Infrastructure.Persistences
{
    public class FrancaContext : DbContext
    {
        public DbSet<Elemento> Elementos { get; set; }

        public DbSet<Sucursal> Sucursales { get; set; }

        public DbSet<Tecnico> Tecnicos { get; set; }

        public DbSet<TecnicoElemento> TecnicoElementos { get; set; }

        public FrancaContext(DbContextOptions<FrancaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataSeed dataSeed = new();

            dataSeed.BuildSucursales(modelBuilder);
            dataSeed.BuildElementos(modelBuilder);

        }
    }
}
