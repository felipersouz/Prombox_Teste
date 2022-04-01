using Microsoft.EntityFrameworkCore.Migrations;

namespace Prombox.Infra.Migrations
{
    public partial class ValorParaNumeroDaSorte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorParaNumeroDaSorte",
                table: "Campanhas",
                type: "DECIMAL(18,4)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorParaNumeroDaSorte",
                table: "Campanhas");
        }
    }
}
