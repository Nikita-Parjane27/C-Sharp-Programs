// Controllers/TestController.cs - to test middleware
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("null-error")]
    public IActionResult TriggerNull()
    {
        throw new ArgumentNullException("testParam");
    }

    [HttpGet("not-found")]
    public IActionResult TriggerNotFound()
    {
        throw new KeyNotFoundException("Item not found in database.");
    }

    [HttpGet("server-error")]
    public IActionResult TriggerServerError()
    {
        throw new Exception("Something went wrong on the server.");
    }
}