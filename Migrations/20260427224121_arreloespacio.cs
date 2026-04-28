using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaDesempeño.Migrations
{
    /// <inheritdoc />
    public partial class arreloespacio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "EspacioDeportivo",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "capacidad",
                table: "EspacioDeportivo",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "EspacioDeportivo");

            migrationBuilder.DropColumn(
                name: "capacidad",
                table: "EspacioDeportivo");
        }
    }
}
