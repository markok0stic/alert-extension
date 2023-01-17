using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace AlertLogger;

public static class AlertLogger
{
    #region >.net6.0
    
    // call this method in Program.cs like this "builder.UseCdmLogger()" before "builder.Build()"
    public static void UseAlertLogger(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Host.UseSerilog((ctx, lc) => { lc
                .ReadFrom.Configuration(builder.Configuration);
        });
    }
    #endregion

    #region <.net6.0
    
    // call this method into Main before Build method call
    public static void UseAlertLoggerMain()
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom
            .Configuration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json")
                .AddJsonFile("appsettings.Production.json")
                .Build())
            .CreateLogger();
    }
    
    // attach this method to "Host.CreateDefaultBuilder(args)"
    public static IHostBuilder UseAlertLogger(this IHostBuilder builder)
    {
        builder.ConfigureLogging(logingBuilder =>
        {
            logingBuilder.ClearProviders();
        });
        return builder.UseSerilog();
    }

    #endregion
}