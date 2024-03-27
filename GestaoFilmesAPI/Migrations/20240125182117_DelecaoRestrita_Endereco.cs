using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoFilmesAPI.Migrations
{
    public partial class DelecaoRestrita_Endereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Enderecos_IdEndereco",
                table: "Cinemas");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Enderecos_IdEndereco",
                table: "Cinemas",
                column: "IdEndereco",
                principalTable: "Enderecos",
                principalColumn: "IdEndereco",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Enderecos_IdEndereco",
                table: "Cinemas");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Enderecos_IdEndereco",
                table: "Cinemas",
                column: "IdEndereco",
                principalTable: "Enderecos",
                principalColumn: "IdEndereco",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
