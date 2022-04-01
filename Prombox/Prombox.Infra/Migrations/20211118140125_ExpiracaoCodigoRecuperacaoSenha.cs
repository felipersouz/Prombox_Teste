using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prombox.Infra.Migrations
{
    public partial class ExpiracaoCodigoRecuperacaoSenha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiracaoCodigoRecuperacaoSenha",
                table: "UsuariosClientes",
                type: "DATETIME",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiracaoCodigoRecuperacaoSenha",
                table: "UsuariosClientes");
        }
    }
}
