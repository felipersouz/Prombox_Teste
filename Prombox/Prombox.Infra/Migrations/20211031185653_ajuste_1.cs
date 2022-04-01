using Microsoft.EntityFrameworkCore.Migrations;

namespace Prombox.Infra.Migrations
{
    public partial class ajuste_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosClientes_Clientes_ClienteId",
                table: "UsuariosClientes");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosClientes_ClienteId",
                table: "UsuariosClientes");

            migrationBuilder.DropColumn(
                name: "CodigoRecuperacaoSenha",
                table: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UsuarioClienteId",
                table: "Clientes",
                column: "UsuarioClienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_UsuariosClientes_UsuarioClienteId",
                table: "Clientes",
                column: "UsuarioClienteId",
                principalTable: "UsuariosClientes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_UsuariosClientes_UsuarioClienteId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_UsuarioClienteId",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "CodigoRecuperacaoSenha",
                table: "Usuarios",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosClientes_ClienteId",
                table: "UsuariosClientes",
                column: "ClienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosClientes_Clientes_ClienteId",
                table: "UsuariosClientes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
