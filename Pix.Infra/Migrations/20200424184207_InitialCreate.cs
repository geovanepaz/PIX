using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pix.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    codigo = table.Column<string>(type: "varchar(255)", nullable: false),
                    quantidade_itens = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "clientes",
                columns: new[] { "Id", "codigo", "nome", "quantidade_itens" },
                values: new object[,]
                {
                    { new Guid("d80a981c-cc80-4f44-a879-291eb712650f"), "ge01", "Geovane", 50 },
                    { new Guid("ce2ddcd9-3f0d-4bca-a539-a095c77dd6a4"), "ma01", "Mariane", 10 },
                    { new Guid("285eb121-10e3-4bc9-9275-fad4c83ad42b"), "jo01", "Jonas", 5 },
                    { new Guid("996d3c4d-6be4-4b86-a3f8-1f2d7d0beee6"), "cl01", "Claudia", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
