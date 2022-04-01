using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prombox.Infra.Migrations
{
    public partial class inicialclean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampanhasLayout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampanhaId = table.Column<int>(type: "int", nullable: false),
                    UrlLogo = table.Column<string>(type: "VARCHAR(1024)", maxLength: 1024, nullable: true),
                    UrlCampanha = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true),
                    UrlRegulamento = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true),
                    UrlInstagram = table.Column<string>(type: "VARCHAR(1024)", maxLength: 1024, nullable: true),
                    UrlComoParticipar = table.Column<string>(type: "VARCHAR(1024)", maxLength: 1024, nullable: true),
                    UrlFacebook = table.Column<string>(type: "VARCHAR(1024)", maxLength: 1024, nullable: true),
                    UrlBanner1 = table.Column<string>(type: "VARCHAR(1024)", maxLength: 1024, nullable: true),
                    UrlBanner2 = table.Column<string>(type: "VARCHAR(1024)", maxLength: 1024, nullable: true),
                    UrlBanner3 = table.Column<string>(type: "VARCHAR(1024)", maxLength: 1024, nullable: true),
                    CorFundoSite = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true),
                    CorBotoes = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true),
                    CorCabecalhoRodape = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhasLayout", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Rg = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    TelPrincipal = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    TelSecundario = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Cep = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Logradouro = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Complemento = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Cidade = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Uf = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true),
                    DataAceiteRegulamento = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Aceite = table.Column<bool>(type: "bit", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    RazaoSocial = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Cnpj = table.Column<string>(type: "VARCHAR(18)", maxLength: 18, nullable: true),
                    Telefone = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    InscricaoMunicipal = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    UrlSite = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    Cep = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: true),
                    Logradouro = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true),
                    Numero = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Complemento = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true),
                    Bairro = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true),
                    Cidade = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true),
                    Uf = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true),
                    Observacoes = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    UrlFacebook = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: true),
                    UrlTwitter = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    UrlInstagram = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    UrlYoutube = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    UrlLinkedin = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    CnpjFaturamento = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    PrecisaOrdemCompra = table.Column<bool>(type: "bit", nullable: true),
                    RazaoSocialFaturamento = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true),
                    DataEnvioNF = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DataVencimento = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosClientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "VARCHAR(70)", maxLength: 70, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataPrimeiroAcesso = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UltimaAlteracaoSenha = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CodigoRecuperacaoSenha = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Hash = table.Column<string>(type: "VARCHAR(90)", maxLength: 90, nullable: true),
                    Salt = table.Column<string>(type: "VARCHAR(90)", maxLength: 90, nullable: true),
                    Pepper = table.Column<string>(type: "VARCHAR(90)", maxLength: 90, nullable: true),
                    BloqueadoAte = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IsExcluido = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioExclusao = table.Column<long>(type: "bigint", nullable: true),
                    DataHoraExclusao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosClientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosClientes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aderentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    Cnpj = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aderentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aderentes_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campanhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    DataInicioCampanha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataFinalCampanha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataLimiteCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataInicioPeriodoCompras = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataFinalPeriodoCompras = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataSorteio = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CertificadoAutorizacao = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true),
                    ResumoRegulamento = table.Column<string>(type: "VARCHAR", nullable: true),
                    EmailSac = table.Column<string>(type: "VARCHAR(70)", maxLength: 70, nullable: true),
                    TelefoneSac = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    TipoCampanha = table.Column<int>(type: "int", nullable: false),
                    IsMaior18Anos = table.Column<bool>(type: "bit", nullable: false),
                    IsLimiteGeografico = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true),
                    Cidade = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    IsLimiteTrocasNF = table.Column<bool>(type: "bit", nullable: false),
                    ValorLimiteNF = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: true),
                    QuantidadeLimiteNF = table.Column<int>(type: "int", nullable: true),
                    IsLimiteGeneroSexual = table.Column<bool>(type: "bit", nullable: false),
                    GeneroSexual = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true),
                    IsBloquearFuncionario = table.Column<bool>(type: "bit", nullable: false),
                    CpfsBloqueados = table.Column<string>(type: "TEXT", nullable: true),
                    RegraParticipacao = table.Column<int>(type: "int", nullable: true),
                    DataEnvioNF = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DataVencimento = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CampanhaLayoutId = table.Column<int>(type: "int", nullable: true),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    UrlImagemGanhadores = table.Column<string>(type: "VARCHAR(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanhas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campanhas_CampanhasLayout_CampanhaLayoutId",
                        column: x => x.CampanhaLayoutId,
                        principalTable: "CampanhasLayout",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Campanhas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoContato = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Cargo = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    Celular = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Telefone = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Observacoes = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contatos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    Telefone = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataPrimeiroAcesso = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UltimaAlteracaoSenha = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CodigoRecuperacaoSenha = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    AvatarUrl = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    Senha = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampanhaAderentes",
                columns: table => new
                {
                    CampanhaId = table.Column<int>(type: "int", nullable: false),
                    AderenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaAderentes", x => new { x.CampanhaId, x.AderenteId });
                    table.ForeignKey(
                        name: "FK_CampanhaAderentes_Aderentes_AderenteId",
                        column: x => x.AderenteId,
                        principalTable: "Aderentes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CampanhaAderentes_Campanhas_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanhas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClientesCampanhas",
                columns: table => new
                {
                    ClienteId = table.Column<long>(type: "bigint", nullable: false),
                    CampanhaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesCampanhas", x => new { x.CampanhaId, x.ClienteId });
                    table.ForeignKey(
                        name: "FK_ClientesCampanhas_Campanhas_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientesCampanhas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuvidasFrequentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pergunta = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    Resposta = table.Column<string>(type: "VARCHAR(2000)", maxLength: 2000, nullable: true),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    CampanhaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuvidasFrequentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuvidasFrequentes_Campanhas_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DuvidasFrequentes_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotasFiscais",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Cod = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Cnpj = table.Column<string>(type: "VARCHAR(18)", maxLength: 18, nullable: true),
                    ValorTotal = table.Column<double>(type: "float", nullable: false),
                    UsuarioClienteId = table.Column<long>(type: "bigint", nullable: false),
                    CampanhaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasFiscais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasFiscais_Campanhas_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanhas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotasFiscais_UsuariosClientes_UsuarioClienteId",
                        column: x => x.UsuarioClienteId,
                        principalTable: "UsuariosClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NumerosDaSorte",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<long>(type: "bigint", nullable: false),
                    CampanhaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<long>(type: "bigint", nullable: true),
                    DataHoraAssociacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumerosDaSorte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumerosDaSorte_Campanhas_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NumerosDaSorte_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ganhadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colocacao = table.Column<int>(type: "int", nullable: false),
                    NumeroDaSorteId = table.Column<long>(type: "bigint", nullable: false),
                    CampanhaId = table.Column<int>(type: "int", nullable: false),
                    CampanhaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ganhadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ganhadores_Campanhas_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanhas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ganhadores_Campanhas_CampanhaId1",
                        column: x => x.CampanhaId1,
                        principalTable: "Campanhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ganhadores_NumerosDaSorte_NumeroDaSorteId",
                        column: x => x.NumeroDaSorteId,
                        principalTable: "NumerosDaSorte",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aderentes_EmpresaId",
                table: "Aderentes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaAderentes_AderenteId",
                table: "CampanhaAderentes",
                column: "AderenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_CampanhaLayoutId",
                table: "Campanhas",
                column: "CampanhaLayoutId",
                unique: true,
                filter: "[CampanhaLayoutId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_EmpresaId",
                table: "Campanhas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesCampanhas_ClienteId",
                table: "ClientesCampanhas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_EmpresaId",
                table: "Contatos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_DuvidasFrequentes_CampanhaId",
                table: "DuvidasFrequentes",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_DuvidasFrequentes_EmpresaId",
                table: "DuvidasFrequentes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ganhadores_CampanhaId",
                table: "Ganhadores",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ganhadores_CampanhaId1",
                table: "Ganhadores",
                column: "CampanhaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ganhadores_NumeroDaSorteId",
                table: "Ganhadores",
                column: "NumeroDaSorteId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_CampanhaId",
                table: "NotasFiscais",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_UsuarioClienteId",
                table: "NotasFiscais",
                column: "UsuarioClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_NumerosDaSorte_CampanhaId",
                table: "NumerosDaSorte",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_NumerosDaSorte_ClienteId",
                table: "NumerosDaSorte",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpresaId",
                table: "Usuarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosClientes_ClienteId",
                table: "UsuariosClientes",
                column: "ClienteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampanhaAderentes");

            migrationBuilder.DropTable(
                name: "ClientesCampanhas");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "DuvidasFrequentes");

            migrationBuilder.DropTable(
                name: "Ganhadores");

            migrationBuilder.DropTable(
                name: "NotasFiscais");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Aderentes");

            migrationBuilder.DropTable(
                name: "NumerosDaSorte");

            migrationBuilder.DropTable(
                name: "UsuariosClientes");

            migrationBuilder.DropTable(
                name: "Campanhas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "CampanhasLayout");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
