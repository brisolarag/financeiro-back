using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace financeiro_back.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedQueries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pago",
                table: "Operacoes");

            migrationBuilder.AddColumn<DateTime>(
                name: "Pagamento",
                table: "Operacoes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pagamento",
                table: "Operacoes");

            migrationBuilder.AddColumn<bool>(
                name: "Pago",
                table: "Operacoes",
                type: "INTEGER",
                nullable: true);
        }
    }
}
