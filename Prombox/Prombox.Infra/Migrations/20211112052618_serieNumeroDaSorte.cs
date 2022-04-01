using Microsoft.EntityFrameworkCore.Migrations;

namespace Prombox.Infra.Migrations
{
    public partial class serieNumeroDaSorte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Serie",
                table: "NumerosDaSorte",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorUtilizado",
                table: "NumeroDaSorteDetalhe",
                type: "DECIMAL(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Serie",
                table: "NumerosDaSorte");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorUtilizado",
                table: "NumeroDaSorteDetalhe",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,4)");
        }
    }
}
