﻿// <auto-generated />
using System;
using Franca.Infrastructure.Persistences;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Franca.Infrastructure.Migrations
{
    [DbContext(typeof(FrancaContext))]
    partial class FrancaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Franca.Domain.Entities.Elemento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Elementos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5ecea05a-379a-4bf2-8f5a-48ece0fbe498"),
                            IsDeleted = false,
                            Name = "Computador"
                        },
                        new
                        {
                            Id = new Guid("957b0b8f-3580-4ee1-81e6-a05e8cc63a1e"),
                            IsDeleted = false,
                            Name = "Monitor"
                        },
                        new
                        {
                            Id = new Guid("1b7c952d-2cab-41de-8ae9-9affd74292e0"),
                            IsDeleted = false,
                            Name = "Telefono fijo"
                        },
                        new
                        {
                            Id = new Guid("18865abe-0d72-4adf-80ee-514cad3d6038"),
                            IsDeleted = false,
                            Name = "Celular"
                        },
                        new
                        {
                            Id = new Guid("3f968188-186e-4741-88d3-2f89677eefff"),
                            IsDeleted = false,
                            Name = "elementos electricos"
                        });
                });

            modelBuilder.Entity("Franca.Domain.Entities.Sucursal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sucursales");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b64808f1-6b15-44a4-9200-5668b8ae6dd7"),
                            IsDeleted = false,
                            Name = "Principal"
                        },
                        new
                        {
                            Id = new Guid("b159b851-3888-4bda-8726-18f6d6508606"),
                            IsDeleted = false,
                            Name = "Segundaria"
                        },
                        new
                        {
                            Id = new Guid("2a51fe5a-d823-433e-8570-ffcbe53cf171"),
                            IsDeleted = false,
                            Name = "Bogota"
                        });
                });

            modelBuilder.Entity("Franca.Domain.Entities.Tecnico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ElementosCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<Guid>("SucursalId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SucursalId");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("Franca.Domain.Entities.TecnicoElemento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ElementoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("TecnicoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ElementoId");

                    b.HasIndex("TecnicoId");

                    b.ToTable("TecnicoElementos");
                });

            modelBuilder.Entity("Franca.Domain.Entities.Tecnico", b =>
                {
                    b.HasOne("Franca.Domain.Entities.Sucursal", "Sucursal")
                        .WithMany("Tecnicos")
                        .HasForeignKey("SucursalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sucursal");
                });

            modelBuilder.Entity("Franca.Domain.Entities.TecnicoElemento", b =>
                {
                    b.HasOne("Franca.Domain.Entities.Elemento", "Elemento")
                        .WithMany("Tecnico")
                        .HasForeignKey("ElementoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Franca.Domain.Entities.Tecnico", "Tecnico")
                        .WithMany("Elementos")
                        .HasForeignKey("TecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Elemento");

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("Franca.Domain.Entities.Elemento", b =>
                {
                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("Franca.Domain.Entities.Sucursal", b =>
                {
                    b.Navigation("Tecnicos");
                });

            modelBuilder.Entity("Franca.Domain.Entities.Tecnico", b =>
                {
                    b.Navigation("Elementos");
                });
#pragma warning restore 612, 618
        }
    }
}