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
                    Amigo_Id = table.Column<Guid>(nullable: false),
                    Jogo_Id = table.Column<Guid>(nullable: false),
                    DataEmprestimo = table.Column<DateTime>(nullable: false),
                    DataDevolucao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Amigos_Amigo_Id",
                        column: x => x.Amigo_Id,
                        principalTable: "Amigos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Jogos_Jogo_Id",
                        column: x => x.Jogo_Id,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_Amigo_Id",
                table: "Emprestimos",
                column: "Amigo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_Jogo_Id",
                table: "Emprestimos",
                column: "Jogo_Id");

            //SEEDS
            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "Id", "Nome", "Plataforma" },
                values: new object[] { "88a5ff3e-6c62-4349-8ffa-136d03e28a02", "Saint Seiya: Soldier´s Soul", 1 });
            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "Id", "Nome", "Plataforma" },
                values: new object[] { "1b620874-8098-4b8e-aac5-abccbbc8f185", "Ace Combat Infinity", 1 });
            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "Id", "Nome", "Plataforma" },
                values: new object[] { "6b27c3b4-6a6f-4db5-a7eb-86f7927d37de", "Transformers: Rise of the Dark Spark", 1 });
            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "Id", "Nome", "Plataforma" },
                values: new object[] { "c96f8c83-28a0-4fbc-9fd2-98c28fe39e00", "God of War III", 1 });
            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "Id", "Nome", "Plataforma" },
                values: new object[] { "bb8e4a59-4d45-4e56-9130-8763103deb58", "Prince of Persia", 2 });
            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "Id", "Nome", "Plataforma" },
                values: new object[] { "1f122f23-1908-434e-962e-d17af1be9f76", "Fifa 21: Edição dos Campeões", 2 });

            migrationBuilder.InsertData(
                table: "Amigos",
                columns: new[] { "Id", "PrimeiroNome", "SobreNome", "Ddd", "Numero" },
                values: new object[] { "635a9b8c-dc47-4080-9ffe-d6ee89ea58c8", "Dawid", "Boyce", "62", "915763254" });
            migrationBuilder.InsertData(
                table: "Amigos",
                columns: new[] { "Id", "PrimeiroNome", "SobreNome", "Ddd", "Numero" },
                values: new object[] { "f0d97a6c-0dba-4a75-9113-38b1c6808620", "Jae", "Burris", "62", "984522143" });
            migrationBuilder.InsertData(
                table: "Amigos",
                columns: new[] { "Id", "PrimeiroNome", "SobreNome", "Ddd", "Numero" },
                values: new object[] { "4d351a4b-39c8-4b8e-9481-0c2223133185", "Ramone", "Berger", "62", "961234755" });
            migrationBuilder.InsertData(
                table: "Amigos",
                columns: new[] { "Id", "PrimeiroNome", "SobreNome", "Ddd", "Numero" },
                values: new object[] { "9dc881bc-a7f4-43d0-9fec-e72e72657162", "Ellesse", "Donnelly", "62", "924568844" });
            migrationBuilder.InsertData(
                table: "Amigos",
                columns: new[] { "Id", "PrimeiroNome", "SobreNome", "Ddd", "Numero" },
                values: new object[] { "46630b53-6596-42af-94cb-d9adbffcd15c", "Zack", "Baker", "62", "989654112" });
            migrationBuilder.InsertData(
                table: "Amigos",
                columns: new[] { "Id", "PrimeiroNome", "SobreNome", "Ddd", "Numero" },
                values: new object[] { "3e86cf05-da04-4c93-9c19-7b792cf0f4d6", "Larry", "Bryan", "62", "996521147" });
            migrationBuilder.InsertData(
                table: "Amigos",
                columns: new[] { "Id", "PrimeiroNome", "SobreNome", "Ddd", "Numero" },
                values: new object[] { "d5c6164a-92d4-4a42-9805-2b141ec58f84", "Ozan", "Knox", "62", "924578874" });
            migrationBuilder.InsertData(
                table: "Amigos",
                columns: new[] { "Id", "PrimeiroNome", "SobreNome", "Ddd", "Numero" },
                values: new object[] { "afbdd30a-0a91-4d56-8748-bff7e77ad9ca", "Angus", "Waters", "62", "952210024" });
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
