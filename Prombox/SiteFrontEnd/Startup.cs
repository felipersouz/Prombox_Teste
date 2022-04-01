using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prombox.Domain.Repositories;
using Prombox.Domain.Services;
using Prombox.Infra.Repositories;
using Prombox.Infra.Transaction;
using Prombox.Service;
using Prombox.Service.Services;
using Prombox.Service.Services.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteFrontEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // EntityFramework
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddControllersWithViews();
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(120);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Dependency Injections
            services.AddDependencyInjections();


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "MyArea",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "cliente",
                    areaName: "cliente",
                    pattern: "cliente/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public static class DependencyInjection
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            //// Dependencias Globais reaproveitáveis na Api e MVC
            //DependencyInjectionGlobal.AddDependencyInjections(services);


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
            services.AddTransient<INumeroDaSorteService, NumeroDaSorteService>();
            services.AddTransient<IClienteCampanhaService, ClienteCampanhaService>();
            services.AddTransient<IMailService, MailService>();
        }
    }

}