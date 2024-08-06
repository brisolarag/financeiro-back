using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace financeiro_back.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Valor = table.Column<double>(type: "REAL", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    DeQuem = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacoes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operacoes");
        }
    }
}
