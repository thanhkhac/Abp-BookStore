using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace BookStore;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        // Logging config
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console())
            .CreateBootstrapLogger();

        try
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host
                .AddAppSettingsSecretsJson() // config appsetting
                // TODO: Tìm hiểu cái này
                // extension dùng để đổi container DI mặc định của .NET (Microsoft DI) sang Autofac – một IoC Container mạnh hơn
                .UseAutofac()
                // Cấu hình log
                .UseSerilog((context, services, loggerConfiguration) =>
                {
                    loggerConfiguration
                        #if DEBUG
                        .MinimumLevel.Debug()
                        #else
                        .MinimumLevel.Information()
                        #endif
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                        .Enrich.FromLogContext()
                        .WriteTo.Async(c => c.File("Logs/logs.txt"))
                        .WriteTo.Async(c => c.Console())
                        .WriteTo.Async(c => c.AbpStudio(services));
                });
            //TODO: Tìm hiểu AddApplicationAsync
            await builder.AddApplicationAsync<BookStoreHttpApiHostModule>();
            var app = builder.Build();
            //TODO: Tìm hiểu InitializeApplicationAsync
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException) { throw; }

            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally { Log.CloseAndFlush(); }
    }
}