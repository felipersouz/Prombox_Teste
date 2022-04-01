using Microsoft.EntityFrameworkCore.Migrations;

namespace Prombox.Infra.Migrations
{
    public partial class ajuste_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EmpresaId",
                table: "Clientes",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_EmpresaId",
                table: "Clientes");
        }
    }
}
