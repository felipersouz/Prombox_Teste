using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prombox.Domain.Entities;

namespace Prombox.Infra.Mappings
{
    public class DuvidaFrequenteMap : IEntityTypeConfiguration<DuvidaFrequente>
    {
        public void Configure(EntityTypeBuilder<DuvidaFrequente> builder)
        {
            builder.ToTable("DuvidasFrequentes");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(x => x.Pergunta).HasColumnName("Pergunta").HasMaxLength(255).HasColumnType("VARCHAR");
            builder.Property(x => x.Resposta).HasColumnName("Resposta").HasMaxLength(2000).HasColumnType("VARCHAR"); ;
            builder.Property(x => x.Ordem).HasColumnName("Ordem");
            builder.Property(x => x.EmpresaId).HasColumnName("EmpresaId");
            builder.Property(x => x.CampanhaId).HasColumnName("CampanhaId");

            builder
                .HasOne(x => x.Campanha)
                .WithMany(x => x.DuvidasFrequentes)
                .HasForeignKey(x => x.CampanhaId);

            builder
                .HasOne(x => x.Empresa)
                .WithMany()
                .HasForeignKey(x => x.EmpresaId);


        }
    }
}