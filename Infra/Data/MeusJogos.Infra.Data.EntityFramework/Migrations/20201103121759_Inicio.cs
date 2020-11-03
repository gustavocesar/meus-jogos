using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeusJogos.Infra.Data.EntityFramework.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amigos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PrimeiroNome = table.Column<string>(nullable: true),
                    SobreNome = table.Column<string>(nullable: true),
                    Ddd = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amigos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Plataforma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AmigoId = table.Column<Guid>(nullable: true),
                    JogoId = table.Column<Guid>(nullable: true),
                    DataEmprestimo = table.Column<DateTime>(nullable: false),
                    DataDevolucao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Amigos_AmigoId",
                        column: x => x.AmigoId,
                        principalTable: "Amigos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Jogos_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_AmigoId",
                table: "Emprestimos",
                column: "AmigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_JogoId",
                table: "Emprestimos",
                column: "JogoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimos");

            migrationBuilder.DropTable(
                name: "Amigos");

            migrationBuilder.DropTable(
                name: "Jogos");
        }
    }
}
