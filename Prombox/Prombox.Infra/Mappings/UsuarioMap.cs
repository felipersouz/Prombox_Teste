using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prombox.Domain.Entities;

namespace Prombox.Infra.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).HasColumnName("Nome").HasMaxLength(100).HasColumnType("VARCHAR");
            builder.Property(x => x.Senha).HasColumnName("Senha").HasMaxLength(100).HasColumnType("VARCHAR");
            builder.Property(x => x.Telefone).HasColumnName("Telefone").HasMaxLength(20).HasColumnType("VARCHAR");
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(100).HasColumnType("VARCHAR");
            builder.Property(x => x.DataCadastro).HasColumnName("DataCadastro").HasColumnType("DATETIME");
            builder.Property(x => x.DataPrimeiroAcesso).HasColumnName("DataPrimeiroAcesso").HasColumnType("DATETIME");
            builder.Property(x => x.UltimaAlteracaoSenha).HasColumnName("UltimaAlteracaoSenha").HasColumnType("DATETIME");
            builder.Property(x => x.Ativo).HasColumnName("Ativo");
            builder.Property(x => x.EmpresaId).HasColumnName("EmpresaId");
            builder.Property(x => x.TipoUsuario).HasColumnName("TipoUsuario");
            builder.Property(x => x.AvatarUrl).HasColumnName("AvatarUrl").HasMaxLength(255).HasColumnType("VARCHAR");

            builder
               .HasOne(x => x.Empresa)
               .WithMany(x => x.Usuarios)
               .HasForeignKey(x => x.EmpresaId);
        }
    }
}
