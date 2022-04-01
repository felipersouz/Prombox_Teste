using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prombox.Domain.Entities;

namespace Prombox.Infra.Mappings
{
    public class CampanhaLayoutMap : IEntityTypeConfiguration<CampanhaLayout>
    {
        public void Configure(EntityTypeBuilder<CampanhaLayout> builder)
        {
            builder.ToTable("CampanhasLayout");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(x => x.UrlLogo).HasColumnName("UrlLogo").HasMaxLength(1024).HasColumnType("VARCHAR");
            builder.Property(x => x.UrlCampanha).HasColumnName("UrlCampanha").HasMaxLength(200).HasColumnType("VARCHAR");
            builder.Property(x => x.UrlRegulamento).HasColumnName("UrlRegulamento").HasMaxLength(200).HasColumnType("VARCHAR");
            builder.Property(x => x.UrlInstagram).HasColumnName("UrlInstagram").HasMaxLength(1024).HasColumnType("VARCHAR");
            builder.Property(x => x.UrlComoParticipar).HasColumnName("UrlComoParticipar").HasMaxLength(1024).HasColumnType("VARCHAR");
            builder.Property(x => x.UrlFacebook).HasColumnName("UrlFacebook").HasMaxLength(1024).HasColumnType("VARCHAR");
            builder.Property(x => x.UrlBanner1).HasColumnName("UrlBanner1").HasMaxLength(1024).HasColumnType("VARCHAR");
            builder.Property(x => x.UrlBanner2).HasColumnName("UrlBanner2").HasMaxLength(1024).HasColumnType("VARCHAR");
            builder.Property(x => x.UrlBanner3).HasColumnName("UrlBanner3").HasMaxLength(1024).HasColumnType("VARCHAR");
            builder.Property(x => x.CorFundoSite).HasColumnName("CorFundoSite").HasMaxLength(30).HasColumnType("VARCHAR");
            builder.Property(x => x.CorBotoes).HasColumnName("CorBotoes").HasMaxLength(30).HasColumnType("VARCHAR");
            builder.Property(x => x.CorCabecalhoRodape).HasColumnName("CorCabecalhoRodape").HasMaxLength(30).HasColumnType("VARCHAR");
            builder.Property(x => x.CampanhaId).HasColumnName("CampanhaId");

            builder
                .HasOne(x => x.Campanha)
                .WithOne(x => x.CampanhaLayout)
                .HasForeignKey<Campanha>(x => x.CampanhaLayoutId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
