using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace SlackAlertLogger;

public static class SlackAlertLogger
{
    #region >.net6.0
    // call this method in Program.cs like this "builder.UseCdmLogger()" before "builder.Build()"
    public static void UseCdmLogger(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Host.UseSerilog((ctx, lc) => { lc
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext();
        });
    }
    #endregion

    #region <.net6.0
    
    // call this method into Main before Build method call call
    public static void UseCdmLoggerMain()
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom
            .Configuration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build())
            .CreateLogger();
    }
    // attach this method to "Host.CreateDefaultBuilder(args)"
    public static IHostBuilder UseCdmLogger(this IHostBuilder builder)
    {
        builder.ConfigureLogging(logingBuilder =>
        {
            logingBuilder.ClearProviders();
        });
        return builder.UseSerilog();
    }

    #endregion
}