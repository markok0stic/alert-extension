# Simple alert package
This nuget uses Serilog and its Sinks Clients for logging anything to specific destination.

This one so far can be used for the following destinations: 
- Slack
- File
- Console

### Installation
Depends on the **.net core version**
- Versions above **6.0**
  Just call method 
``` 
// ./Program.cs
builder.UseAlertLogger()
```
- Versions below **6.0**

  In Main.cs call this static method:
```
// ./Main.cs
// before Build() call
AlertLoggerExtension.UseAlertLoggerMain()
```
```
// ./Program.cs 
Host.CreateDefaultBuilder(args).UseAlertLogger()
```
## JSON config
- In appsettings.json configure these params:
- _Notes_:
  - _Dont forget to set the ASPNETCORE_ENVIRONMENT variable for production_
  - (.net < 6.0) _If you have appsettings.${Environment}.json please prefer to put any of the json config inside those files_
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
- Possible log levels [LogEventLevel](https://github.com/serilog/serilog/blob/dev/src/Serilog/Events/LogEventLevel.cs).
- Read more about this configuration on [Serilog](https://serilog.net/) and [Serilog.Sinks.Slack](https://github.com/serilog-contrib/serilog-sinks-slackclient).
