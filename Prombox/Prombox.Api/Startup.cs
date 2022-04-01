using System;
using System.Threading.Tasks;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using Prombox.Domain.Repositories;
using Prombox.Domain.Services;
using Prombox.Service.Services;
using Prombox.Web.Settings;
using Prombox.Infra.Transaction;
using Prombox.Infra.Repositories;
using Swashbuckle.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Prombox.Api.Context;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using Prombox.Service.Services.Mail;
using Prombox.Service;

namespace Prombox.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // EntityFramework
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Cors
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // JWT
            services.AddAuthorization(Configuration);
            // Dependency Injections
            services.AddDependencyInjections();
            // MVC
            services.AddMvc(o => o.EnableEndpointRouting = false).AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1",
                    Description = "API",
                    License = new OpenApiLicense { Name = "None" },
                    Contact = new OpenApiContact
                    {
                        Name = "Prombox",
                        Email = string.Empty,
                        Url = new Uri("http://prombox.com.br/")
                    }
                });
            });
            // Log Elmah
            services.AddElmah<SqlErrorLog>(options =>
            {
                options.Path = @"elmah";
                options.ConnectionString = Configuration["ConnectionStrings:DefaultConnection"];
            });

            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseElmah();
            //app.UseCors("CorsPolicy");
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseDefaultFiles();

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
                RequestPath = new PathString("/StaticFiles")
            });


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
                c.DocExpansion(DocExpansion.None);
            });

            app.UseMvc();
        }
    }

    public static class DependencyInjection
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            services.AddTransient<ICurrentUser, CurrentUser>();

            // Dependencias Globais reaproveitáveis na Api e MVC
            DependencyInjectionGlobal.AddDependencyInjections(services);
        }

        public static void AddAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            var signingConfiguration = new SigningConfiguration(configuration);
            services.AddSingleton(signingConfiguration);

            var tokenConfiguration = new TokenConfiguration();
            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                configuration.GetSection("TokenConfiguration"))
                    .Configure(tokenConfiguration);
            services.AddSingleton(tokenConfiguration);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfiguration.Key;
                paramsValidation.ValidAudience = tokenConfiguration.Audience;
                paramsValidation.ValidIssuer = tokenConfiguration.Issuer;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda � v�lido
                paramsValidation.ValidateLifetime = true;

                // Tempo de toler�ncia para a expira��o de um token (utilizado
                // caso haja problemas de sincronismo de hor�rio entre diferentes
                // computadores envolvidos no processo de comunica��o)
                paramsValidation.ClockSkew = TimeSpan.Zero;

                bearerOptions.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        return Task.CompletedTask;
                    }
                };

            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
        }
    }
}
