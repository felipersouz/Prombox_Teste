using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prombox.Domain.Entities;

namespace Prombox.Infra.Mappings
{
    public class NumeroDaSorteMap : IEntityTypeConfiguration<NumeroDaSorte>
    {
        public void Configure(EntityTypeBuilder<NumeroDaSorte> builder)
        {
            builder.ToTable("NumerosDaSorte");
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(x => x.Numero).HasColumnName("Numero").IsRequired();
            builder.Property(x => x.CampanhaId).HasColumnName("CampanhaId").IsRequired();
            builder.Property(x => x.ClienteId).HasColumnName("ClienteId");
            builder.Property(x => x.DataHoraAssociacao).HasColumnName("DataHoraAssociacao").HasColumnType("DATETIME");
            builder.Property(x => x.Serie).HasColumnName("Serie").HasDefaultValue(0);

            builder
                .HasOne(x => x.Campanha)
                .WithMany()
                .HasForeignKey(x => x.CampanhaId);

            builder
                .HasOne(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.ClienteId);

            builder
                .HasMany(x => x.Detalhes)
                .WithOne(x => x.NumeroDaSorte);                
        }
    }
}
