using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prombox.Domain.Entities;

namespace Prombox.Infra.Mappings
{
    public class UsuarioClienteMap : IEntityTypeConfiguration<UsuarioCliente>
    {
        public void Configure(EntityTypeBuilder<UsuarioCliente> builder)
        {
            builder.ToTable("UsuariosClientes");
            builder.Property(x => x.Id).HasColumnName("Id");            
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(70).HasColumnType("VARCHAR").IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnName("DataCadastro").HasColumnType("DATETIME").IsRequired();
            builder.Property(x => x.DataPrimeiroAcesso).HasColumnName("DataPrimeiroAcesso").HasColumnType("DATETIME");
            builder.Property(x => x.UltimaAlteracaoSenha).HasColumnName("UltimaAlteracaoSenha").HasColumnType("DATETIME");
            builder.Property(x => x.Ativo).HasColumnName("Ativo").IsRequired();
            builder.Property(x => x.CodigoRecuperacaoSenha).HasColumnName("CodigoRecuperacaoSenha").HasMaxLength(20).HasColumnType("VARCHAR");
            builder.Property(x => x.ClienteId).HasColumnName("ClienteId").IsRequired();
            builder.Property(x => x.PasswordHash).HasColumnName("Hash").HasMaxLength(90).HasColumnType("VARCHAR");
            builder.Property(x => x.Salt).HasColumnName("Salt").HasMaxLength(90).HasColumnType("VARCHAR");
            builder.Property(x => x.Pepper).HasColumnName("Pepper").HasMaxLength(90).HasColumnType("VARCHAR");
            builder.Property(x => x.BloqueadoAte).HasColumnName("BloqueadoAte").HasColumnType("DATETIME");
            builder.Property(x => x.IsExcluido).HasColumnName("IsExcluido").IsRequired();
            builder.Property(x => x.UsuarioExclusao).HasColumnName("UsuarioExclusao");
            builder.Property(x => x.DataHoraExclusao).HasColumnName("DataHoraExclusao").HasColumnType("DATETIME");
            builder.Property(x => x.ExpiracaoCodigoRecuperacaoSenha).HasColumnName("ExpiracaoCodigoRecuperacaoSenha").HasColumnType("DATETIME");
        }
    }
}

