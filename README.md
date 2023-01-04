# Simple slack alert package
Uses Serilog and its Slack Client for logging anything to specific slack channel.

### Installation
 Depends on the .net core version
 - Versions above 6.0
 Just call method builder.UseCdmLogger() in the program.cs
 - Versions below 6.0
 In a Main call this static method CdmLogger.UseCdmLoggerMain() before Build() call
 In program.cs attach UseCdmLogger() method to "Host.CreateDefaultBuilder(args)"
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
 - Read more about this configuration on [Serilog](https://serilog.net/) and [Serilog.Sinks.Slack](https://github.com/serilog-contrib/serilog-sinks-slackclient).
