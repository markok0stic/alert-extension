# Simple slack alert package
Uses Serilog and its Slack Client for logging anything to specific slack channel.

### Installation
 Depends on .net core version
 - Versions above 6.0
 Just call method builder.UseCdmLogger() in program.cs
 - Versions below 6.0
 In Main call this static method CdmLogger.UseCdmLoggerMain() before Build() call
 In program.cs attach UseCdmLogger() method to "Host.CreateDefaultBuilder(args)"
