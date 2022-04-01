using Prombox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Infra.Mappings
{
    public class NotaFiscalMap : IEntityTypeConfiguration<NotaFiscal>
    {
        public void Configure(EntityTypeBuilder<NotaFiscal> builder)
        {
            builder.ToTable("NotasFiscais");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(x => x.DataCompra).HasColumnName("DataCompra").HasColumnType("DATETIME");
            builder.Property(x => x.DataCadastro).HasColumnName("DataCadastro").HasColumnType("DATETIME");
            builder.Property(x => x.Cod).HasColumnName("Cod").HasMaxLength(20).HasColumnType("VARCHAR");
            builder.Property(x => x.Cnpj).HasColumnName("Cnpj").HasMaxLength(18).HasColumnType("VARCHAR");
            builder.Property(x => x.ValorTotal).HasColumnName("ValorTotal").HasColumnType("DECIMAL(18,4)");
            builder.Property(x => x.Saldo).HasColumnName("Saldo").HasColumnType("DECIMAL(18,4)");
            builder.Property(x => x.UsuarioClienteId).HasColumnName("UsuarioClienteId");
            builder.Property(x => x.CampanhaId).HasColumnName("CampanhaId");

            builder
                .HasOne(x => x.UsuarioCliente)
                .WithMany()
                .HasForeignKey(x => x.UsuarioClienteId);

            builder
                .HasOne(x => x.Campanha)
                .WithMany(x => x.NotasFiscais)
                .HasForeignKey(x => x.CampanhaId);


        }
    }
}