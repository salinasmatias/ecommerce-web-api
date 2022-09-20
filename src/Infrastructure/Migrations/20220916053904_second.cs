using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orden_CarritoId",
                table: "Orden");

            migrationBuilder.RenameColumn(
                name: "Marva",
                table: "Producto",
                newName: "Marca");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_CarritoId",
                table: "Orden",
                column: "CarritoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orden_CarritoId",
                table: "Orden");

            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Producto",
                newName: "Marva");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_CarritoId",
                table: "Orden",
                column: "CarritoId");
        }
    }
}
