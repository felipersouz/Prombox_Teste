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
    public class CampanhaAderenteMap : IEntityTypeConfiguration<CampanhaAderente>
    {
        public void Configure(EntityTypeBuilder<CampanhaAderente> builder)
        {
            builder.ToTable("CampanhaAderentes");

            builder.HasKey(x => new { x.CampanhaId, x.AderenteId });

            builder.Property(x => x.AderenteId).HasColumnName("AderenteId");
            builder.Property(x => x.CampanhaId).HasColumnName("CampanhaId");

            builder
               .HasOne(x => x.Aderente)
               .WithMany(x => x.CampanhaAderentes)
               .HasForeignKey(x => x.AderenteId)
               .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Campanha)
                .WithMany(x => x.CampanhaAderentes)
                .HasForeignKey(x => x.CampanhaId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
