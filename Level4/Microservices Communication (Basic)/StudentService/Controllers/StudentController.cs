using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IHttpClientFactory _httpClient;

    public StudentController(IHttpClientFactory httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(string name, string email)
    {
        // Step 1: Register student
        Console.WriteLine($"Student {name} registered.");

        // Step 2: Call NotificationService to send welcome email
        var client = _httpClient.CreateClient();
        var response = await client.GetAsync(
            $"http://localhost:5002/api/notification/send?to={email}&message=Welcome {name}!");

        if (response.IsSuccessStatusCode)
            return Ok($"Student {name} registered and notified!");
        else
            return Ok($"Student {name} registered but notification failed.");
    }
}