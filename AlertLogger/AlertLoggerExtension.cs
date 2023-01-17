using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace AlertLogger;

public static class AlertLoggerExtension
{
    #region >.net6.0
    
    // call this method in Program.cs like this "builder.UseAlertLogger()" before "builder.Build()"
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
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        Log.Logger = new LoggerConfiguration()
            .ReadFrom
            .Configuration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env}.json", optional:true)
                .Build())
            .CreateLogger();
    }
    
    // attach this method to "Host.CreateDefaultBuilder(args)"
    public static IHostBuilder UseAlertLogger(this IHostBuilder builder)
    {
        builder.ConfigureLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
        });
        return builder.UseSerilog();
    }

    #endregion
}