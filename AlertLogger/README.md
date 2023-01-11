# Simple slack alert package
This nuget use Serilog and its Sinks Clients for logging anything to specific destination.
This one so far is for: 
- Slack
- File
- Console

### Installation
Depends on the .net core version
- Versions above 6.0
  Just call method builder.UseAlertLogger() in the program.cs
- Versions below 6.0
  In a Main call this static method CdmLogger.UseAlertLoggerMain() before Build() call
  In program.cs attach UseAlertLogger() method to "Host.CreateDefaultBuilder(args)"
- Source code:
  https://github.com/markok0stic/slack-alert-extension
- In appsettings.json configure these params:
```JSON
"Serilog": {
    "MinimumLevel": "Information",
    "WriteTo": [
      {
        "Name": "Console",
        "Args":
        {
          "restrictedToMinimumLevel": "Information"
        }
      },
      {
        "Name": "File",
        "Args":
        {
          "path": "log.txt",
          "rollingInterval": "Day",
          "restrictedToMinimumLevel": "Error"
        }
      },
      {
        "Name": "Slack",
        "Args": 
        {
          "webhookUrl": "https://hooks.slack.com/services/xxx/yyyy",
          "batchSizeLimit": 20,
          "queueLimit": 1000,
          "showDefaultAttachments": true,
          "showExceptionAttachments": true,
          "restrictedToMinimumLevel": 4,
          "outputTemplate": "",
          "propertyDenyList": [ "ActionId", "RequestId", "ConnectionId" ]
        }
      }
    ]
  }
```
- You can exclude any of above mentioned Serilog configs (sinks) in order to not use them at all.
- Possible log levels https://github.com/serilog/serilog/blob/dev/src/Serilog/Events/LogEventLevel.cs.
- Read more about this configuration on [Serilog](https://serilog.net/) and [Serilog.Sinks.Slack](https://github.com/serilog-contrib/serilog-sinks-slackclient).
