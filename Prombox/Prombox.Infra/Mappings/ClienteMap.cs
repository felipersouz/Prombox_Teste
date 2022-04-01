using Prombox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Infra.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).HasColumnName("Nome").HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Cpf).HasColumnName("Cpf").HasColumnType("VARCHAR").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Rg).HasColumnName("Rg").HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(x => x.DataNascimento).HasColumnName("DataNascimento").HasColumnType("DATETIME");
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("VARCHAR").HasMaxLength(100);
            builder.Property(x => x.TelPrincipal).HasColumnName("TelPrincipal").HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(x => x.TelSecundario).HasColumnName("TelSecundario").HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(x => x.Cep).HasColumnName("Cep").HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(x => x.Logradouro).HasColumnName("Logradouro").HasColumnType("VARCHAR").HasMaxLength(100);
            builder.Property(x => x.Numero).HasColumnName("Numero").HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(x => x.Complemento).HasColumnName("Complemento").HasColumnType("VARCHAR").HasMaxLength(50);
            builder.Property(x => x.Bairro).HasColumnName("Bairro").HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(x => x.Cidade).HasColumnName("Cidade").HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(x => x.Uf).HasColumnName("Uf").HasColumnType("VARCHAR").HasMaxLength(2);
            builder.Property(x => x.DataAceiteRegulamento).HasColumnName("DataAceiteRegulamento").HasColumnType("DATETIME");
            builder.Property(x => x.Aceite).HasColumnName("Aceite");
            builder.Property(x => x.EmpresaId).HasColumnName("EmpresaId");

            builder
               .HasOne(x => x.Empresa)
               .WithMany()
               .HasForeignKey(x => x.EmpresaId);

            builder
                .HasOne<UsuarioCliente>(s => s.UsuarioCliente)
                .WithOne(uc => uc.Cliente)
                .HasForeignKey<UsuarioCliente>(uc => uc.ClienteId);

        }
    }
}
