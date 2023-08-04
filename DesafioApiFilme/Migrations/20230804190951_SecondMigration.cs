using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioApiFilme.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "Horario",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "Sala",
                table: "Sessoes");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes");

            migrationBuilder.AddColumn<string>(
                name: "Horario",
                table: "Sessoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Sala",
                table: "Sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
