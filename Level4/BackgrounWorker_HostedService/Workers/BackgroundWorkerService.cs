using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

public class BackgroundWorkerService : BackgroundService
{
    private readonly ILogger<BackgroundWorkerService> _logger;

    public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Background Worker started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation($"Worker running at: {DateTime.Now}");

            // Simulate background task (e.g., cleanup, report generation)
            await DoBackgroundWork();

            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }

        _logger.LogInformation("Background Worker stopped.");
    }

    private Task DoBackgroundWork()
    {
        Console.WriteLine($"[{DateTime.Now}] Background task executed - cleaning temp files...");
        return Task.CompletedTask;
    }
}