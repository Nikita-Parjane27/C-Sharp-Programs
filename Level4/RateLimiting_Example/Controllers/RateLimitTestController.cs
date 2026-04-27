using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RateLimitTestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Request successful! (Max 5 per minute per IP)");
    }
}