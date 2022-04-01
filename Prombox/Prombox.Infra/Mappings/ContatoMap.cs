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
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contatos");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).IsRequired().HasColumnName("Nome").HasMaxLength(100).HasColumnType("VARCHAR");
            builder.Property(x => x.Cargo).HasColumnName("Cargo").HasMaxLength(60).HasColumnType("VARCHAR");
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(255).HasColumnType("VARCHAR");
            builder.Property(x => x.Celular).HasColumnName("Celular").HasMaxLength(20).HasColumnType("VARCHAR");
            builder.Property(x => x.Telefone).HasColumnName("Telefone").HasMaxLength(20).HasColumnType("VARCHAR");
            builder.Property(x => x.Observacoes).HasColumnName("Observacoes").HasMaxLength(255).HasColumnType("VARCHAR");
            builder.Property(x => x.TipoContato).HasColumnName("TipoContato");
            builder.Property(x => x.Ativo).HasColumnName("Ativo");
            builder.Property(x => x.EmpresaId).HasColumnName("EmpresaId");

            builder
               .HasOne(x => x.Empresa)
               .WithMany(x => x.Contatos)
               .HasForeignKey(x => x.EmpresaId);

        }
    }
}
