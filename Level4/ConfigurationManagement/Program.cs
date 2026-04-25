// Install: dotnet add package Microsoft.Extensions.Configuration
// dotnet add package Microsoft.Extensions.Configuration.Json

using System;
using Microsoft.Extensions.Configuration;

class AppSettingsDemo
{
    static void Main()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        string appName = config["AppSettings:AppName"];
        string version  = config["AppSettings:Version"];
        string dbConn   = config["ConnectionStrings:DefaultConnection"];

        Console.WriteLine($"App Name   : {appName}");
        Console.WriteLine($"Version    : {version}");
        Console.WriteLine($"DB Connect : {dbConn}");
    }
}