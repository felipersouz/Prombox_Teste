using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prombox.Domain.Entities;

namespace Prombox.Infra.Mappings
{
    public class AderenteMap : IEntityTypeConfiguration<Aderente>
    {
        public void Configure(EntityTypeBuilder<Aderente> builder)
        {
            builder.ToTable("Aderentes");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).HasColumnName("Nome").HasMaxLength(100).HasColumnType("VARCHAR");
            builder.Property(x => x.Cnpj).HasColumnName("Cnpj").HasMaxLength(20).HasColumnType("VARCHAR"); ;
            builder.Property(x => x.EmpresaId).HasColumnName("EmpresaId");
            builder.Property(x => x.Ativa).HasColumnName("Ativa");

            builder
                .HasOne(x => x.Empresa)
                .WithMany()
                .HasForeignKey(x => x.EmpresaId);


        }
    }
}
