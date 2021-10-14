using DevReviews.API.Persistence;
using DevReviews.API.Persistence.Repositories;
using DevReviews.API.Profiles;
using DevReviews.API.Services;
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
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // PARA ACESSO AO BANCO EM MEMÓRIA
            // services.AddDbContext<DevReviewsDbContext>(o => o.UseInMemoryDatabase("DevReviewsDb"));

            // PARA ACESSO AO SQL Server
            // Busca string de conexão e seta o banco de dados
            // var connectionString = Configuration.GetValue<string>("DevReviewsCs");
            // services.AddDbContext<DevReviewsDbContext>(o => o.UseSqlServer(connectionString));

            // PARA ACESSO AO SQLite
            var connectionString = Configuration.GetConnectionString("DevReviewsCs");
            services.AddDbContext<DevReviewsDbContext>(o => o.UseSqlite(connectionString));

            // PARA ACESSO AO SQL Server
            // Busca string de conexão e seta o banco de dados
            // var connectionString = Configuration.GetValue<string>("DevReviewsCs");
            // services.AddDbContext<DevReviewsDbContext>(o => o.UseSqlServer(connectionString));

            // Injeção de Dependência
            // Tipos: Transient, Scoped, Singleton
            // Padrão Repository
            // services.AddSingleton<DevReviewsDbContext>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddControllers();

            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo
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
                o.IncludeXmlComments(xmlPath);
            });

            // AutoMapper
            services.AddAutoMapper(typeof(ProductProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // INFO: Swagger visível só em desenvolvimento
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(o =>
                {
                    o.RoutePrefix = string.Empty;
                    o.SwaggerEndpoint("/swagger/v1/swagger.json", "DevReviews.API v1");
                });
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