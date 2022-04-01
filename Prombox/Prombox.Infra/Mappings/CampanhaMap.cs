using Prombox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Infra.Mappings
{
    public class CampanhaMap : IEntityTypeConfiguration<Campanha>
    {
        public void Configure(EntityTypeBuilder<Campanha> builder)
        {
            builder.ToTable("Campanhas");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName("Nome").HasMaxLength(100).HasColumnType("VARCHAR");
            builder.Property(x => x.DataInicioCampanha).HasColumnName("DataInicioCampanha").HasColumnType("DATETIME");
            builder.Property(x => x.DataFinalCampanha).HasColumnName("DataFinalCampanha").HasColumnType("DATETIME");
            builder.Property(x => x.DataLimiteCadastro).HasColumnName("DataLimiteCadastro").HasColumnType("DATETIME");
            builder.Property(x => x.DataInicioPeriodoCompras).HasColumnName("DataInicioPeriodoCompras").HasColumnType("DATETIME");
            builder.Property(x => x.DataFinalPeriodoCompras).HasColumnName("DataFinalPeriodoCompras").HasColumnType("DATETIME");
            builder.Property(x => x.DataSorteio).HasColumnName("DataSorteio").HasColumnType("DATETIME");
            builder.Property(x => x.ResumoRegulamento).HasColumnName("ResumoRegulamento").HasColumnType("VARCHAR");
            builder.Property(x => x.CertificadoAutorizacao).HasColumnName("CertificadoAutorizacao").HasMaxLength(200).HasColumnType("VARCHAR");
            builder.Property(x => x.EmailSac).HasColumnName("EmailSac").HasMaxLength(70).HasColumnType("VARCHAR");
            builder.Property(x => x.TelefoneSac).HasColumnName("TelefoneSac").HasMaxLength(20).HasColumnType("VARCHAR");
            builder.Property(x => x.EmpresaId).HasColumnName("EmpresaId");
            builder.Property(x => x.TipoCampanha).HasColumnName("TipoCampanha");
            builder.Property(x => x.IsMaior18Anos).HasColumnName("IsMaior18Anos");
            builder.Property(x => x.IsLimiteGeografico).HasColumnName("IsLimiteGeografico");
            builder.Property(x => x.Estado).HasColumnName("Estado").HasMaxLength(2).HasColumnType("VARCHAR");
            builder.Property(x => x.Cidade).HasColumnName("Cidade").HasMaxLength(50).HasColumnType("VARCHAR");
            builder.Property(x => x.Bairro).HasColumnName("Bairro").HasMaxLength(50).HasColumnType("VARCHAR");
            builder.Property(x => x.IsLimiteTrocasNF).HasColumnName("IsLimiteTrocasNF");
            builder.Property(x => x.ValorLimiteNF).HasColumnName("ValorLimiteNF").HasColumnType("DECIMAL(18,4)");
            builder.Property(x => x.ValorParaNumeroDaSorte).HasColumnName("ValorParaNumeroDaSorte").HasColumnType("DECIMAL(18,4)");
            builder.Property(x => x.QuantidadeLimiteNF).HasColumnName("QuantidadeLimiteNF");
            builder.Property(x => x.IsLimiteGeneroSexual).HasColumnName("IsLimiteGeneroSexual");
            builder.Property(x => x.GeneroSexual).HasMaxLength(2).HasColumnName("GeneroSexual").HasColumnType("VARCHAR");
            builder.Property(x => x.IsBloquearFuncionario).HasColumnName("IsBloquearFuncionario");
            builder.Property(x => x.CpfsBloqueados).HasColumnName("CpfsBloqueados").HasColumnType("TEXT");
            builder.Property(x => x.RegraParticipacao).HasColumnName("RegraParticipacao");
            builder.Property(x => x.CampanhaLayoutId).HasColumnName("CampanhaLayoutId");
            builder.Property(x => x.DataEnvioNF).HasColumnName("DataEnvioNF").HasColumnType("DATETIME");
            builder.Property(x => x.DataVencimento).HasColumnName("DataVencimento").HasColumnType("DATETIME");
            builder.Property(x => x.Ativa).HasColumnName("Ativa");
            builder.Property(x => x.UrlImagemGanhadores).HasColumnName("UrlImagemGanhadores").HasMaxLength(512).HasColumnType("VARCHAR");


            builder
                .HasOne(x => x.Empresa)
                .WithMany()
                .HasForeignKey(x => x.EmpresaId);

            builder
                .HasOne(x => x.CampanhaLayout)
                .WithOne(x => x.Campanha)
                .HasForeignKey<CampanhaLayout>(x => x.CampanhaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
              .HasMany(c => c.DuvidasFrequentes)
              .WithOne(e => e.Campanha);

            builder
              .HasMany(c => c.NotasFiscais)
              .WithOne(e => e.Campanha);

            builder
              .HasMany(c => c.Ganhadores)
              .WithOne(e => e.Campanha);

        }
    }
}
