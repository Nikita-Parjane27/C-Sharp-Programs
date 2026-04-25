// Install: dotnet add package Serilog
// dotnet add package Serilog.Sinks.Console
// dotnet add package Serilog.Sinks.File

using System;
using Serilog;

class SerilogDemo
{
    static void Main()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Log.Information("Application Started");
        Log.Debug("Debug message - checking values");
        Log.Warning("Warning! Something might be wrong");

        try
        {
            int result = Divide(10, 0);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred during division");
        }

        Log.Information("Application Ended");
        Log.CloseAndFlush();
    }

    static int Divide(int a, int b)
    {
        if (b == 0) throw new DivideByZeroException("Cannot divide by zero!");
        return a / b;
    }
}