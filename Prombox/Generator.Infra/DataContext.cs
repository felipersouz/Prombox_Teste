using Microsoft.EntityFrameworkCore;
using Prombox.Generator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Generator.Infra
{
    public class DataContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DuvidaFrequente> DuvidasFrequentes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<Campanha> Campanhas { get; set; }
        public DbSet<CampanhaLayout> CampanhasLayout { get; set; }
        public DbSet<UsuarioCliente> UsuariosClientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Dev_Prombox;Integrated Security=true;MultipleActiveResultSets=True");
        }
    }
}
