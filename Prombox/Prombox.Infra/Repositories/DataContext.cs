using Prombox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Prombox.Infra.Mappings;

namespace Prombox.Infra.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {

        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Aderente> Aderentes { get; set; }
        public DbSet<Campanha> Campanhas { get; set; }
        public DbSet<CampanhaLayout> CampanhasLayout { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteCampanha> ClientesCampanhas { get; set; }
        public DbSet<DuvidaFrequente> DuvidasFrequentes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<UsuarioCliente> UsuariosClientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CampanhaAderente> CampanhaAderentes { get; set; }
        public DbSet<Ganhador> Ganhadores { get; set; }
        public DbSet<NumeroDaSorte> NumerosDaSorte { get; set; }
        public DbSet<NumeroDaSorteDetalhe> NumerosDaSorteDetalhes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AderenteMap());
            modelBuilder.ApplyConfiguration(new CampanhaMap());
            modelBuilder.ApplyConfiguration(new CampanhaLayoutMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new DuvidaFrequenteMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new ContatoMap());
            modelBuilder.ApplyConfiguration(new NotaFiscalMap());
            modelBuilder.ApplyConfiguration(new UsuarioClienteMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CampanhaAderenteMap());
            modelBuilder.ApplyConfiguration(new GanhadorMap());
            modelBuilder.ApplyConfiguration(new NumeroDaSorteMap());
            modelBuilder.ApplyConfiguration(new ClienteCampanhaMap());
            modelBuilder.ApplyConfiguration(new NumeroDaSorteDetalheMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=.\\;Initial Catalog=Dev_Prombox4;Integrated Security=True");
            }
        }
    }
}
