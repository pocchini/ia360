using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CardPlay.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NomeTitular = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    CodigoAmigavel = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    Saldo = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    DescricaoCurta = table.Column<string>(type: "TEXT", maxLength: 160, nullable: false),
                    Preco = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Icone = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    Disponivel = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacoesCartao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CartaoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacoesCartao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentacoesCartao_Cartoes_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "DescricaoCurta", "Disponivel", "Icone", "Nome", "Preco" },
                values: new object[,]
                {
                    { new Guid("6f1c2a7e-0c4a-4b1d-9e2f-1a2b3c4d5e6f"), "Um espresso cremoso para começar bem o dia.", true, "☕", "Café especial", 8.50m },
                    { new Guid("7a2d3b8f-1d5b-4c2e-8f3a-2b3c4d5e6f70"), "História curta com arte colorida para ler no intervalo.", true, "📘", "Livro ilustrado", 32.90m },
                    { new Guid("8b3e4c9a-2e6c-4d3f-9a4b-3c4d5e6f7081"), "Áudio leve para estudar ou ouvir um podcast.", true, "🎧", "Fone compacto", 79.00m },
                    { new Guid("9c4f5d0b-3f7d-4e4a-ab5c-4d5e6f708192"), "Um sticker brilhante para personalizar seu caderno.", true, "🌟", "Adesivo CardPlay", 4.00m },
                    { new Guid("ad506e1c-408e-4f5b-bc6d-5e6f708192a3"), "Combo doce e salgado para recarregar a energia.", true, "🥪", "Lanche da tarde", 18.75m },
                    { new Guid("be617f2d-519f-406c-cd7e-6f708192a3b4"), "Algodão macio com estampa do cartão virtual.", true, "👕", "Camiseta lúdica", 59.90m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacoesCartao_CartaoId",
                table: "MovimentacoesCartao",
                column: "CartaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentacoesCartao");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Cartoes");
        }
    }
}
