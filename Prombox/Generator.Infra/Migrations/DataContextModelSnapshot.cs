﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prombox.Generator.Infra;

namespace Prombox.Generator.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prombox.Domain.Entities.Aderente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CampanhaId")
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("CampanhaId");

                    b.ToTable("Aderente");
                });

            modelBuilder.Entity("Prombox.Domain.Entities.Campanha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("CertificadoAutorizacao")
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Cidade")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("CpfsBloqueados")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataFinalCampanha")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataFinalPeriodoCompras")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataInicioCampanha")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataInicioPeriodoCompras")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataLimiteCadastro")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataSorteio")
                        .HasColumnType("DATETIME");

                    b.Property<string>("EmailSac")
                        .HasMaxLength(70)
                        .HasColumnType("VARCHAR(70)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasMaxLength(2)
                        .HasColumnType("VARCHAR(2)");

                    b.Property<string>("GeneroSexual")
                        .HasMaxLength(2)
                        .HasColumnType("VARCHAR(2)");

                    b.Property<bool>("IsBloquearFuncionario")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLimiteGeneroSexual")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLimiteGeografico")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLimiteTrocasNF")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMaior18Anos")
                        .HasColumnType("bit");

                    b.Property<int?>("QuantidadeLimiteNF")
                        .HasColumnType("int");

                    b.Property<int>("RegraParticipacao")
                        .HasColumnType("int");

                    b.Property<string>("ResumoRegulamento")
                        .HasColumnType("VARCHAR");

                    b.Property<string>("TelefoneSac")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<int>("TipoCampanha")
                        .HasColumnType("int");

                    b.Property<decimal?>("ValorLimiteNF")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Campanhas");
                });

            modelBuilder.Entity("Prombox.Domain.Entities.CampanhaLayout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CampanhaId")
                        .HasColumnType("int");

                    b.Property<string>("CorBotoes")
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("CorCabecalhoRodape")
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("CorFundoSite")
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("UrlBanner1")
                        .HasMaxLength(512)
                        .HasColumnType("VARCHAR(512)");

                    b.Property<string>("UrlBanner2")
                        .HasMaxLength(512)
                        .HasColumnType("VARCHAR(512)");

                    b.Property<string>("UrlBanner3")
                        .HasMaxLength(512)
                        .HasColumnType("VARCHAR(512)");

                    b.Property<string>("UrlCampanha")
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("UrlComoParticipar")
                        .HasMaxLength(512)
                        .HasColumnType("VARCHAR(512)");

                    b.Property<string>("UrlFacebook")
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("UrlInstagram")
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("UrlLogo")
                        .HasMaxLength(512)
                        .HasColumnType("VARCHAR(512)");

                    b.Property<string>("UrlRegulamento")
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("Id");

                    b.HasIndex("CampanhaId")
                        .IsUnique();

                    b.ToTable("CampanhasLayout");
                });

            modelBuilder.Entity("Prombox.Domain.Entities.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aceite")
                        .HasColumnType("bit");

                    b.Property<string>("Bairro")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Cep")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Cidade")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Cpf")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<DateTime?>("DataAceiteRegulamento")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Logradouro")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Numero")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Rg")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("TelPrincipal")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("TelSecundario")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Uf")
                        .HasMaxLength(2)
                        .HasColumnType("VARCHAR(2)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Prombox.Domain.Entities.DuvidaFrequente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CampanhaId")
                        .HasColumnType("int");

                    b.Property<int>("Ordem")
                        .HasColumnType("int");

                    b.Property<string>("Pergunta")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Resposta")
                        .HasMaxLength(2000)
                        .HasColumnType("VARCHAR(2000)");

                    b.HasKey("Id");

                    b.HasIndex("CampanhaId");

                    b.ToTable("DuvidasFrequentes");
                });

            modelBuilder.Entity("Prombox.Domain.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativa")
                        .HasColumnType("bit");

                    b.Property<string>("Bairro")
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Cep")
                        .HasMaxLength(9)
                        .HasColumnType("VARCHAR(9)");

                    b.Property<string>("Cidade")
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("CnpjFaturamento")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<DateTime>("DataEnvioNF")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("InscricaoMunicipal")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Logradouro")
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("NomeFantasia")
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Numero")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Observacoes")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<bool>("PrecisaOrdemCompra")
                        .HasColumnType("bit");

                    b.Property<string>("RazaoSocial")
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("RazaoSocialFaturamento")
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Uf")
                        .HasMaxLength(2)
                        .HasColumnType("VARCHAR(2)");

                    b.Property<string>("UrlFacebook")
                        .HasMaxLength(1000)
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<string>("UrlInstagram")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("UrlLinkedin")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("UrlSite")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("UrlTwitter")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("UrlYoutube")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Prombox.Domain.Entities.NotaFiscal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj")
                        .HasMaxLength(18)
                        .HasColumnType("VARCHAR(18)");

                    b.Property<string>("Cod")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("DATETIME");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("NotasFiscais");
                });

            modelBuilder.Entity("Prombox.Domain.Entities.UsuarioCliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("BloqueadoAte")
                        .HasColumnType("DATETIME");

                    b.Property<string>("CodigoRecuperacaoSenha")
                        .HasMaxLength(16)
                        .HasColumnType("VARCHAR(16)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("DataHoraExclusao")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("DataPrimeiroAcesso")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Email")
                        .HasMaxLength(70)
                        .HasColumnType("VARCHAR(70)");

                    b.Property<string>("Hash")
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR(30)");

                    b.Property<bool>("IsExcluido")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasMaxLength(70)
                        .HasColumnType("VARCHAR(70)");

                    b.Property<string>("Pepper")
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR(30)");

                    b.Property<DateTime?>("UltimaAlteracaoSenha")
                        .HasColumnType("DATETIME");

                    b.Property<long?>("UsuarioExclusao")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("UsuariosClientes");
                });

            modelBuilder.Entity("Prombox.Domain.Entities.Aderente", b =>
                {
                    b.HasOne("Prombox.Domain.Entities.Campanha", null)
                        .WithMany("Aderentes")
                        .HasForeignKey("CampanhaId");
                });

            modelBuilder.Entity("Prombox.Domain.Entities.Campanha", b =>
                {
                    b.HasOne("Prombox.Domain.Entities.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Prombox.Domain.Entities.CampanhaLayout", b =>
                {
                    b.HasOne("Prombox.Domain.Entities.Campanha", null)
                        .WithOne("CampanhaLayout")
                        .HasForeignKey("Prombox.Domain.Entities.CampanhaLayout", "CampanhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prombox.Domain.Entities.DuvidaFrequente", b =>
                {
                    b.HasOne("Prombox.Domain.Entities.Campanha", "Campanha")
                        .WithMany("DuvidasFrequentes")
                        .HasForeignKey("CampanhaId");

                    b.Navigation("Campanha");
                });

            modelBuilder.Entity("Prombox.Domain.Entities.Campanha", b =>
                {
                    b.Navigation("Aderentes");

                    b.Navigation("CampanhaLayout");

                    b.Navigation("DuvidasFrequentes");
                });
#pragma warning restore 612, 618
        }
    }
}
