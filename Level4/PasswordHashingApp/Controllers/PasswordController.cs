using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PasswordController : ControllerBase
{
    [HttpPost("hash")]
    public IActionResult HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            return BadRequest("Password cannot be empty.");

        string hashed = BCrypt.Net.BCrypt.HashPassword(password);
        return Ok(new
        {
            OriginalPassword = password,
            HashedPassword   = hashed
        });
    }

    [HttpPost("verify")]
    public IActionResult VerifyPassword(string password, string hashedPassword)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
            return BadRequest("Both fields are required.");

        bool isMatch = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        return Ok(new
        {
            Password       = password,
            IsMatch        = isMatch,
            Message        = isMatch ? "Password matched! ✅" : "Wrong password! ❌"
        });
    }

    [HttpPost("register")]
    public IActionResult Register(string username, string password)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        return Ok(new
        {
            Username       = username,
            HashedPassword = hashedPassword,
            Message        = "User registered with hashed password!"
        });
    }
}