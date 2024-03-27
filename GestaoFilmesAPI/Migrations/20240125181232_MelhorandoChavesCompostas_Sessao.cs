using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoFilmesAPI.Migrations
{
    public partial class MelhorandoChavesCompostas_Sessao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaIdCinema",
                table: "Sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Filmes_FilmeIdFilme",
                table: "Sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes");

            migrationBuilder.DropIndex(
                name: "IX_Sessoes_CinemaIdCinema",
                table: "Sessoes");

            migrationBuilder.DropIndex(
                name: "IX_Sessoes_FilmeIdFilme",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "IdSessao",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "CinemaIdCinema",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "FilmeIdFilme",
                table: "Sessoes");

            migrationBuilder.AlterColumn<int>(
                name: "IdFilme",
                table: "Sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCinema",
                table: "Sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes",
                columns: new[] { "IdFilme", "IdCinema" });

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_IdCinema",
                table: "Sessoes",
                column: "IdCinema");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Cinemas_IdCinema",
                table: "Sessoes",
                column: "IdCinema",
                principalTable: "Cinemas",
                principalColumn: "IdCinema",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Filmes_IdFilme",
                table: "Sessoes",
                column: "IdFilme",
                principalTable: "Filmes",
                principalColumn: "IdFilme",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Cinemas_IdCinema",
                table: "Sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Filmes_IdFilme",
                table: "Sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes");

            migrationBuilder.DropIndex(
                name: "IX_Sessoes_IdCinema",
                table: "Sessoes");

            migrationBuilder.AlterColumn<int>(
                name: "IdCinema",
                table: "Sessoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdFilme",
                table: "Sessoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdSessao",
                table: "Sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "CinemaIdCinema",
                table: "Sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FilmeIdFilme",
                table: "Sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes",
                column: "IdSessao");

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_CinemaIdCinema",
                table: "Sessoes",
                column: "CinemaIdCinema");

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_FilmeIdFilme",
                table: "Sessoes",
                column: "FilmeIdFilme");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaIdCinema",
                table: "Sessoes",
                column: "CinemaIdCinema",
                principalTable: "Cinemas",
                principalColumn: "IdCinema",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Filmes_FilmeIdFilme",
                table: "Sessoes",
                column: "FilmeIdFilme",
                principalTable: "Filmes",
                principalColumn: "IdFilme",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
