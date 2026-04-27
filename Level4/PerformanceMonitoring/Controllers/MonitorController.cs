using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

[ApiController]
[Route("api/[controller]")]
public class MonitorController : ControllerBase
{
    private static List<string> _logs = new();

    [HttpGet("health")]
    public IActionResult HealthCheck()
    {
        var health = new
        {
            Status      = "Healthy",
            Time        = DateTime.UtcNow,
            Environment = System.Environment.MachineName
        };
        _logs.Add($"[{DateTime.UtcNow}] Health check called.");
        return Ok(health);
    }

    [HttpGet("performance")]
    public IActionResult GetPerformance()
    {
        var sw = Stopwatch.StartNew();

        // Simulate some work
        long sum = 0;
        for (int i = 0; i < 1000000; i++)
            sum += i;

        sw.Stop();

        var result = new
        {
            TaskCompleted    = true,
            Sum              = sum,
            TimeTakenMs      = sw.ElapsedMilliseconds,
            MemoryUsedBytes  = GC.GetTotalMemory(false)
        };

        _logs.Add($"[{DateTime.UtcNow}] Performance check: {sw.ElapsedMilliseconds}ms");
        return Ok(result);
    }

    [HttpGet("logs")]
    public IActionResult GetLogs()
    {
        return Ok(_logs);
    }

    [HttpDelete("logs/clear")]
    public IActionResult ClearLogs()
    {
        _logs.Clear();
        return Ok("Logs cleared.");
    }
}