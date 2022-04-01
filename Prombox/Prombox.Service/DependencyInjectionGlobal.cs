using Microsoft.Extensions.DependencyInjection;
using Prombox.Domain.Repositories;
using Prombox.Domain.Services;
using Prombox.Infra.Repositories;
using Prombox.Infra.Transaction;
using Prombox.Service.Services;
using Prombox.Service.Services.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Service
{
    public static class DependencyInjectionGlobal
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {

            // Repository
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAderenteRepository, AderenteRepository>();
            services.AddTransient<ICampanhasRepository, CampanhaRepository>();
            services.AddTransient<ICampanhasLayoutRepository, CampanhaLayoutRepository>();
            services.AddTransient<IClientesRepository, ClienteRepository>();
            services.AddTransient<IDuvidasFrequentesRepository, DuvidsFrequenteRepository>();
            services.AddTransient<IEmpresasRepository, EmpresaRepository>();
            services.AddTransient<INotasFiscaisRepository, NotaFiscalRepository>();
            services.AddTransient<IUsuariosClientesRepository, UsuarioClienteRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IContatosRepository, ContatoRepository>();
            services.AddTransient<IGanhadoresRepository, GanhadoresRepository>();
            services.AddTransient<INumeroDaSorteRepository, NumeroDaSorteRepository>();
            services.AddTransient<IClienteCampanhaRepository, ClienteCampanhaRepository>();


            // Service
            services.AddTransient<IAderenteService, AderenteService>();
            services.AddTransient<ICampanhasService, CampanhasService>();
            services.AddTransient<ICampanhasLayoutService, CampanhasLayoutService>();
            services.AddTransient<IClientesService, ClientesService>();
            services.AddTransient<IDuvidasFrequentesService, DuvidasFrequentesService>();
            services.AddTransient<IEmpresasService, EmpresasService>();
            services.AddTransient<INotasFiscaisService, NotasFiscaisService>();
            services.AddTransient<IUsuariosClientesService, UsuarioClienteService>();
            services.AddTransient<IUsuariosService, UsuariosService>();
            services.AddTransient<IContatosService, ContatosService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IGanhadoresService, GanhadoresService>();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<INumeroDaSorteService, NumeroDaSorteService>();
            services.AddTransient<IClienteCampanhaService, ClienteCampanhaService>();
            
        }
    }
}
