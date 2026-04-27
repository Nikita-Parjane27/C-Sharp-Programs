using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    [HttpGet("send")]
    public IActionResult Send(string to, string message)
    {
        // Simulate sending email
        Console.WriteLine($"[NotificationService] Email sent to {to}: {message}");
        return Ok($"Notification sent to {to}");
    }
}