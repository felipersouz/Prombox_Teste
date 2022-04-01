using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prombox.Infra.Migrations
{
    public partial class AlteracoesNotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "NotasFiscais",
                newName: "DataCompra");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "NumerosDaSorte",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "NotasFiscais",
                type: "DATETIME",
                nullable: false);

            migrationBuilder.AddColumn<double>(
                name: "Saldo",
                table: "ClientesCampanhas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "NumeroDaSorteDetalhe",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDaSorteId = table.Column<long>(type: "bigint", nullable: false),
                    ValorUtilizado = table.Column<double>(type: "float", nullable: false),
                    NotaFiscalId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroDaSorteDetalhe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumeroDaSorteDetalhe_NotasFiscais_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "NotasFiscais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NumeroDaSorteDetalhe_NumerosDaSorte_NumeroDaSorteId",
                        column: x => x.NumeroDaSorteId,
                        principalTable: "NumerosDaSorte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NumeroDaSorteDetalhe_NotaFiscalId",
                table: "NumeroDaSorteDetalhe",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_NumeroDaSorteDetalhe_NumeroDaSorteId",
                table: "NumeroDaSorteDetalhe",
                column: "NumeroDaSorteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumeroDaSorteDetalhe");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "NumerosDaSorte");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "NotasFiscais");

            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "ClientesCampanhas");

            migrationBuilder.RenameColumn(
                name: "DataCompra",
                table: "NotasFiscais",
                newName: "Data");
        }
    }
}
