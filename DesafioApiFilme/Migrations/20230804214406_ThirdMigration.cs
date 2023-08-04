using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioApiFilme.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeUf",
                table: "Ufs",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "SiglaUfId",
                table: "Ufs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NomeCidade",
                table: "Cidades",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "IdCidade",
                table: "Cidades",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Ufs",
                newName: "NomeUf");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ufs",
                newName: "SiglaUfId");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Cidades",
                newName: "NomeCidade");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cidades",
                newName: "IdCidade");
        }
    }
}
