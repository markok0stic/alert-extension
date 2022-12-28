using Microsoft.Extensions.Logging;

namespace SlackAlertLogger.Services;

public interface IAlertLoggerService<T>
{
    
}
public class AlertLoggerService<T>
{
    private readonly ILogger<T> _logger;

    public AlertLoggerService(ILogger<T> logger)
    {
        _logger = logger;
    }

    public void LogInformation(dynamic value)
    {
        
    } 
}