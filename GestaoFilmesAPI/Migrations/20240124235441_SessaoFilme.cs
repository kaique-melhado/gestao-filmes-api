using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoFilmesAPI.Migrations
{
    public partial class SessaoFilme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sessoes",
                columns: table => new
                {
                    IdSessao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdFilme = table.Column<int>(type: "int", nullable: false),
                    FilmeIdFilme = table.Column<int>(type: "int", nullable: false),
                    IdCinema = table.Column<int>(type: "int", nullable: false),
                    CinemaIdCinema = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessoes", x => x.IdSessao);
                    table.ForeignKey(
                        name: "FK_Sessoes_Cinemas_CinemaIdCinema",
                        column: x => x.CinemaIdCinema,
                        principalTable: "Cinemas",
                        principalColumn: "IdCinema",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessoes_Filmes_FilmeIdFilme",
                        column: x => x.FilmeIdFilme,
                        principalTable: "Filmes",
                        principalColumn: "IdFilme",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_CinemaIdCinema",
                table: "Sessoes",
                column: "CinemaIdCinema");

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_FilmeIdFilme",
                table: "Sessoes",
                column: "FilmeIdFilme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessoes");
        }
    }
}
