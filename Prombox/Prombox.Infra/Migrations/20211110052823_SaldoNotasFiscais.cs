using Microsoft.EntityFrameworkCore.Migrations;

namespace Prombox.Infra.Migrations
{
    public partial class SaldoNotasFiscais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "ClientesCampanhas");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorUtilizado",
                table: "NumeroDaSorteDetalhe",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTotal",
                table: "NotasFiscais",
                type: "DECIMAL(18,4)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<decimal>(
                name: "Saldo",
                table: "NotasFiscais",
                type: "DECIMAL(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorParaNumeroDaSorte",
                table: "Campanhas",
                type: "DECIMAL(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,4)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "NotasFiscais");

            migrationBuilder.AlterColumn<double>(
                name: "ValorUtilizado",
                table: "NumeroDaSorteDetalhe",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "ValorTotal",
                table: "NotasFiscais",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,4)");

            migrationBuilder.AddColumn<double>(
                name: "Saldo",
                table: "ClientesCampanhas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorParaNumeroDaSorte",
                table: "Campanhas",
                type: "DECIMAL(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,4)");
        }
    }
}
