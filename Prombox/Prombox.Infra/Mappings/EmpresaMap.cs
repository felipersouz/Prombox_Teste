using Prombox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Infra.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(x => x.Ativa).HasColumnName("Ativa");
            builder.Property(x => x.RazaoSocial).IsRequired().HasColumnName("RazaoSocial").HasColumnType("VARCHAR").HasMaxLength(60);
            builder.Property(x => x.NomeFantasia).IsRequired().HasColumnName("NomeFantasia").HasColumnType("VARCHAR").HasMaxLength(60);
            builder.Property(x => x.Cnpj).HasColumnName("Cnpj").HasColumnType("VARCHAR").HasMaxLength(18);
            builder.Property(x => x.Telefone).HasColumnName("Telefone").HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(x => x.InscricaoMunicipal).HasColumnName("InscricaoMunicipal").HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(x => x.InscricaoEstadual).HasColumnName("InscricaoEstadual").HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(x => x.UrlSite).HasColumnName("UrlSite").HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.Cep).HasColumnName("Cep").HasColumnType("VARCHAR").HasMaxLength(10);
            builder.Property(x => x.Logradouro).HasColumnName("Logradouro").HasColumnType("VARCHAR").HasMaxLength(60);
            builder.Property(x => x.Numero).HasColumnName("Numero").HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(x => x.Complemento).HasColumnName("Complemento").HasColumnType("VARCHAR").HasMaxLength(60);
            builder.Property(x => x.Bairro).HasColumnName("Bairro").HasColumnType("VARCHAR").HasMaxLength(60);
            builder.Property(x => x.Cidade).HasColumnName("Cidade").HasColumnType("VARCHAR").HasMaxLength(60);
            builder.Property(x => x.Uf).HasColumnName("Uf").HasColumnType("VARCHAR").HasMaxLength(2);
            builder.Property(x => x.Observacoes).HasColumnName("Observacoes").HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.UrlFacebook).HasColumnName("UrlFacebook").HasColumnType("VARCHAR").HasMaxLength(1000);
            builder.Property(x => x.UrlTwitter).HasColumnName("UrlTwitter").HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.UrlInstagram).HasColumnName("UrlInstagram").HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.UrlYoutube).HasColumnName("UrlYoutube").HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.UrlLinkedin).HasColumnName("UrlLinkedin").HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.CnpjFaturamento).HasColumnName("CnpjFaturamento").HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(x => x.PrecisaOrdemCompra).HasColumnName("PrecisaOrdemCompra");
            builder.Property(x => x.RazaoSocialFaturamento).HasColumnName("RazaoSocialFaturamento").HasColumnType("VARCHAR").HasMaxLength(60);
            builder.Property(x => x.DataEnvioNF).HasColumnName("DataEnvioNF").HasColumnType("DATETIME");
            builder.Property(x => x.DataVencimento).HasColumnName("DataVencimento").HasColumnType("DATETIME");

            builder
                .HasMany(e => e.Contatos)
                .WithOne(e => e.Empresa)
                .HasForeignKey(e => e.EmpresaId);

            builder
                .HasMany(e => e.Aderentes)
                .WithOne(e => e.Empresa)
                .HasForeignKey(e => e.EmpresaId);

            builder
                .HasMany(e => e.Usuarios)
                .WithOne(e => e.Empresa)
                .HasForeignKey(e => e.EmpresaId);


        }
    }
}
