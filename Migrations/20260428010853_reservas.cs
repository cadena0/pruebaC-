using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaDesempeño.Migrations
{
    /// <inheritdoc />
    public partial class reservas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EspacioDeportivoId",
                table: "Reservas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Reservas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "horaFim",
                table: "Reservas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "horaInicio",
                table: "Reservas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EspacioDeportivoId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "horaFim",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "horaInicio",
                table: "Reservas");
        }
    }
}
