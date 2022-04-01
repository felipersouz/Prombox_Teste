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
    public class GanhadorMap : IEntityTypeConfiguration<Ganhador>
    {
        public void Configure(EntityTypeBuilder<Ganhador> builder)
        {
            builder.ToTable("Ganhadores");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(x => x.Colocacao).HasColumnName("Colocacao").IsRequired();
            builder.Property(x => x.NumeroDaSorteId).HasColumnName("NumeroDaSorteId").IsRequired();
            builder.Property(x => x.CampanhaId).HasColumnName("CampanhaId").IsRequired();

            builder
                .HasOne(x => x.Campanha)
                .WithMany(x => x.Ganhadores)
                .HasForeignKey(x => x.CampanhaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.NumeroDaSorte)
                .WithMany()
                .HasForeignKey(x => x.NumeroDaSorteId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
