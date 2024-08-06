using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace financeiro_back.Migrations
{
    /// <inheritdoc />
    public partial class addIsFaturaOnSaidaEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFatura",
                table: "Operacoes",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFatura",
                table: "Operacoes");
        }
    }
}
