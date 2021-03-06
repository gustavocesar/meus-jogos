using System;
using System.Threading.Tasks;
using MeusJogos.Contexts.JogoContext.Application.Handlers;
using MeusJogos.Contexts.JogoContext.Application.Handlers.Contracts;
using MeusJogos.Contexts.JogoContext.Application.QueryService;
using MeusJogos.Contexts.JogoContext.Application.QueryService.Contracts;
using MeusJogos.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MeusJogos.Contexts.AmigoContext.Application.Handlers.Contracts;
using MeusJogos.Contexts.AmigoContext.Application.Handlers;
using MeusJogos.Contexts.AmigoContext.Application.QueryService.Contracts;
using MeusJogos.Contexts.AmigoContext.Application.QueryService;
using MeusJogos.Contexts.EmprestimoContext.Application.Handlers.Contracts;
using MeusJogos.Contexts.EmprestimoContext.Application.QueryService.Contracts;
using MeusJogos.Contexts.EmprestimoContext.Application.QueryService;
using MeusJogos.Contexts.EmprestimoContext.Application.Handlers;
using Microsoft.OpenApi.Models;
using System.Text;
using System.ComponentModel;
using MeusJogos.Infra.CrossCutting.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Api
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
            services.AddDbContext<DataContext>(
                 options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddTransient<IJogoCommandHandler, JogoCommandHandler>();
            services.AddTransient<IJogoQueryService, JogoQueryService>();
            services.AddTransient<IAmigoCommandHandler, AmigoCommandHandler>();
            services.AddTransient<IAmigoQueryService, AmigoQueryService>();
            services.AddTransient<IEmprestimoCommandHandler, EmprestimoCommandHandler>();
            services.AddTransient<IEmprestimoQueryService, EmprestimoQueryService>();
            services.AddScoped<DataContext, DataContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Meus Jogos", Version = "v1" });
            });

            services.AddCors();
            services.AddControllers();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                context.Database.Migrate();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Configurando Swagger
            app.UseSwagger();
            app.UseSwaggerUI(option => option.SwaggerEndpoint("/swagger/v1/swagger.json", "get API V1"));
            app.UseWelcomePage("/swagger");

            app.Run(context =>
            {
                context.Response.Redirect("/swagger/index.html");
                return Task.CompletedTask;
            });
        }
    }
}
