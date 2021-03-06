using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace DevReviews.API
{
    public class Program
    {
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    //var settings = config.Build();

                    Serilog.Log.Logger = new LoggerConfiguration()

                        // PARA LOG NO SQL Server
                        //.WriteTo.MSSqlServer(
                        //    settings.GetValue<string>("DevReviewsCn"),
                        //    sinkOptions: new MSSqlServerSinkOptions()
                        //    {
                        //        TableName = "Logs",
                        //        AutoCreateSqlTable = true
                        //    })

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