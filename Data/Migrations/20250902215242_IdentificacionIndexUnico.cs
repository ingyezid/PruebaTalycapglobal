using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTalycapglobal.Migrations
{
    public partial class IdentificacionIndexUnico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Identificacion",
                table: "Clientes",
                column: "Identificacion",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_Identificacion",
                table: "Clientes");
        }
    }
}
