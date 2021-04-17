using Microsoft.EntityFrameworkCore.Migrations;

namespace ToyStore.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Toys", new string[] { "Id", "Nombre", "Descripcion", "RestriccionEdad", "Compania", "Precio", }, new object[] {1, "Jenga", "Jenga Hasbro a los must have de diversión que no podrán faltar en tu hogar.", 10, "Hasbro", 359 });
            migrationBuilder.InsertData("Toys", new string[] { "Id", "Nombre", "Descripcion", "RestriccionEdad", "Compania", "Precio", }, new object[] {2, "Laptop Aprende Conmigo", "¡Esta laptop de juguete mantiene a los bebés ocupados!", 1, "Fisher Price", 539 });
            migrationBuilder.InsertData("Toys", new string[] { "Id", "Nombre", "Descripcion", "RestriccionEdad", "Compania", "Precio", }, new object[] {3, "Woody - Toy Story 4", "Posee un diseño lleno de detalles únicos que lo hacen una pieza perfecta", 3, "Disney Collection", 524.30 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
