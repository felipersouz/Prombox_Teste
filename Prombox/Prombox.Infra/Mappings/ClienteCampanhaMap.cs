using Prombox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Infra.Mappings
{
    public class ClienteCampanhaMap : IEntityTypeConfiguration<ClienteCampanha>
    {
        public void Configure(EntityTypeBuilder<ClienteCampanha> builder)
        {
            builder.ToTable("ClientesCampanhas");
            builder.HasKey(cc => new { cc.CampanhaId, cc.ClienteId });
            //builder.Property(x => x.Saldo).HasColumnName("Saldo");

            builder
                .HasOne<Campanha>(cc => cc.Campanha)
                .WithMany(camp => camp.ClientesCampanhas)
                .HasForeignKey(cc => cc.CampanhaId);

            builder
                .HasOne<Cliente>(cc => cc.Cliente)
                .WithMany(cli => cli.ClientesCampanhas)
                .HasForeignKey(cc => cc.ClienteId);

        }
    }
}
