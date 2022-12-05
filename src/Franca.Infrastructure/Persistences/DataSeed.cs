using Franca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Infrastructure.Persistences
{
    public class DataSeed
    {
        public DataSeed()
        {

        }

        public void BuildSucursales(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sucursal>().HasData(Sucursal.Build(
                name: "Principal"));

            modelBuilder.Entity<Sucursal>().HasData(Sucursal.Build(
                name: "Segundaria"));

            modelBuilder.Entity<Sucursal>().HasData(Sucursal.Build(
                name: "Bogota"));
        }

        public void BuildElementos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Elemento>().HasData(Elemento.Build(
                name: "Computador"));

            modelBuilder.Entity<Elemento>().HasData(Elemento.Build(
                name: "Monitor"));

            modelBuilder.Entity<Elemento>().HasData(Elemento.Build(
                name: "Telefono fijo"));

            modelBuilder.Entity<Elemento>().HasData(Elemento.Build(
                name: "Celular"));

            modelBuilder.Entity<Elemento>().HasData(Elemento.Build(
                name: "elementos electricos"));
        }
    }
}
