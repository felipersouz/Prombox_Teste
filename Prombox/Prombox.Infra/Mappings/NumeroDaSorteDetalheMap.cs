using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Infra.Mappings
{
    public class NumeroDaSorteDetalheMap : IEntityTypeConfiguration<NumeroDaSorteDetalhe>
    {
        public void Configure(EntityTypeBuilder<NumeroDaSorteDetalhe> builder)
        {
            builder.ToTable("NumeroDaSorteDetalhe");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            
            builder.Property(x => x.NumeroDaSorteId).HasColumnName("NumeroDaSorteId").IsRequired();
            builder.Property(x => x.ValorUtilizado).HasColumnName("ValorUtilizado").HasColumnType("DECIMAL(18,4)").IsRequired();
            builder.Property(x => x.NotaFiscalId).HasColumnName("NotaFiscalId").IsRequired();

            //builder
            //    .HasOne(x => x.NumeroDaSorte)
            //    .WithMany()
            //    .HasForeignKey(x => x.NumeroDaSorteId);

            //builder
            //    .HasOne(x => x.NotaFiscal)
            //    .WithMany()
            //    .HasForeignKey(x => x.NotaFiscalId);
        }
    }
}
