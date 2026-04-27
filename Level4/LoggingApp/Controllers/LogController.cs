using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LogController : ControllerBase
{
    private readonly ILogger<LogController> _logger;

    public LogController(ILogger<LogController> logger)
    {
        _logger = logger;
    }

    [HttpGet("info")]
    public IActionResult Info()
    {
        _logger.LogInformation("Info endpoint called at {Time}", DateTime.UtcNow);
        return Ok("Info logged!");
    }

    [HttpGet("warning")]
    public IActionResult Warning()
    {
        _logger.LogWarning("Warning endpoint called - something might be wrong!");
        return Ok("Warning logged!");
    }

    [HttpGet("error")]
    public IActionResult Error()
    {
        try
        {
            throw new Exception("Test error for logging!");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred at {Time}", DateTime.UtcNow);
            return StatusCode(500, "Error logged!");
        }
    }

    [HttpGet("debug")]
    public IActionResult Debug()
    {
        _logger.LogDebug("Debug info: Request from {IP}", HttpContext.Connection.RemoteIpAddress);
        return Ok("Debug logged!");
    }
}