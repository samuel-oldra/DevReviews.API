using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace DevReviews.API
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    //var settings = config.Build();

                    Serilog.Log.Logger = new LoggerConfiguration()

                        // PARA LOG NO SQL Server
                        // .WriteTo.MSSqlServer(
                        //     settings.GetValue<string>("DevReviewsCn"),
                        //     sinkOptions: new MSSqlServerSinkOptions()
                        //     {
                        //         TableName = "Logs",
                        //         AutoCreateSqlTable = true
                        //     })

                        // PARA LOG NO SQlite
                        .WriteTo.SQLite(Environment.CurrentDirectory + @"\Data\dados.db")

                        // PARA LOG NO CONSOLE
                        .WriteTo.Console()

                        .CreateLogger();
                })
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}