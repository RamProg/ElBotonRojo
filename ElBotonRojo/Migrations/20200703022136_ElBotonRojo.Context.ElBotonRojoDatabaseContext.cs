using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElBotonRojo.Migrations
{
    public partial class ElBotonRojoContextElBotonRojoDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 15, nullable: false),
                    Apodo = table.Column<string>(maxLength: 30, nullable: false),
                    Residencia = table.Column<string>(maxLength: 100, nullable: false),
                    Edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clicks = table.Column<int>(nullable: false),
                    IdJugador = table.Column<int>(nullable: false),
                    Apodo = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidas_Jugadores_IdJugador",
                        column: x => x.IdJugador,
                        principalTable: "Jugadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_IdJugador",
                table: "Partidas",
                column: "IdJugador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.DropTable(
                name: "Jugadores");
        }
    }
}
