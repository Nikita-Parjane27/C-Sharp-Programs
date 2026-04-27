using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SecretController : ControllerBase
{
    private static Dictionary<string, string> _secrets = new();

    [HttpPost("set")]
    public IActionResult SetSecret(string name, string value)
    {
        _secrets[name] = value;
        return Ok($"Secret '{name}' stored successfully.");
    }

    [HttpGet("get/{name}")]
    public IActionResult GetSecret(string name)
    {
        if (!_secrets.ContainsKey(name))
            return NotFound($"Secret '{name}' not found.");
        return Ok(new { Name = name, Value = _secrets[name] });
    }

    [HttpDelete("delete/{name}")]
    public IActionResult DeleteSecret(string name)
    {
        if (!_secrets.ContainsKey(name))
            return NotFound($"Secret '{name}' not found.");
        _secrets.Remove(name);
        return Ok($"Secret '{name}' deleted.");
    }

    [HttpGet("list")]
    public IActionResult ListSecrets()
    {
        return Ok(_secrets.Keys);
    }
}