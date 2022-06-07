using DevReviews.API.Persistence;
using DevReviews.API.Persistence.Repositories;
using DevReviews.API.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace DevReviews.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // PARA ACESSO AO BANCO EM MEMÓRIA
            services.AddDbContext<DevReviewsDbContext>(o => o.UseInMemoryDatabase("DevGamesDb"));

            // PARA ACESSO AO SQL Server
            // Busca string de conexão e seta o banco de dados
            // var connectionString = Configuration.GetValue<string>("DevReviewsCn");
            // services.AddDbContext<DevReviewsDbContext>(o => o.UseSqlServer(connectionString));

            // Injeção de Dependência
            // Tipos: Transient, Scoped, Singleton
            // services.AddSingleton<DevReviewsDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // AutoMapper
            services.AddAutoMapper(typeof(ProductProfile));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DevReviews.API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Samuel B. Oldra",
                        Email = "samuel.oldra@gmail.com",
                        Url = new Uri("https://github.com/samuel-oldra")
                    }
                });

                // Incluindo comentários XML ao Swagger
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Se quiser liberar Swagger em produção, mudar esse if
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevReviews.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}