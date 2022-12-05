using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Franca.Infrastructure.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elementos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elementos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    SucursalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ElementosCount = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tecnicos_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TecnicoElementos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TecnicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ElementoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnicoElementos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TecnicoElementos_Elementos_ElementoId",
                        column: x => x.ElementoId,
                        principalTable: "Elementos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TecnicoElementos_Tecnicos_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Elementos",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("18865abe-0d72-4adf-80ee-514cad3d6038"), false, "Celular" },
                    { new Guid("1b7c952d-2cab-41de-8ae9-9affd74292e0"), false, "Telefono fijo" },
                    { new Guid("3f968188-186e-4741-88d3-2f89677eefff"), false, "elementos electricos" },
                    { new Guid("5ecea05a-379a-4bf2-8f5a-48ece0fbe498"), false, "Computador" },
                    { new Guid("957b0b8f-3580-4ee1-81e6-a05e8cc63a1e"), false, "Monitor" }
                });

            migrationBuilder.InsertData(
                table: "Sucursales",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("2a51fe5a-d823-433e-8570-ffcbe53cf171"), false, "Bogota" },
                    { new Guid("b159b851-3888-4bda-8726-18f6d6508606"), false, "Segundaria" },
                    { new Guid("b64808f1-6b15-44a4-9200-5668b8ae6dd7"), false, "Principal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TecnicoElementos_ElementoId",
                table: "TecnicoElementos",
                column: "ElementoId");

            migrationBuilder.CreateIndex(
                name: "IX_TecnicoElementos_TecnicoId",
                table: "TecnicoElementos",
                column: "TecnicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tecnicos_SucursalId",
                table: "Tecnicos",
                column: "SucursalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TecnicoElementos");

            migrationBuilder.DropTable(
                name: "Elementos");

            migrationBuilder.DropTable(
                name: "Tecnicos");

            migrationBuilder.DropTable(
                name: "Sucursales");
        }
    }
}
