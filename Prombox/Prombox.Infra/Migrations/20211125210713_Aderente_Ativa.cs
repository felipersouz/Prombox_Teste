using Microsoft.EntityFrameworkCore.Migrations;

namespace Prombox.Infra.Migrations
{
    public partial class Aderente_Ativa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "Aderentes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "Aderentes");
        }
    }
}
