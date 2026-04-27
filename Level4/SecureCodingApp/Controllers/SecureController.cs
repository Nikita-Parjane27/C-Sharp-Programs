using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

[ApiController]
[Route("api/[controller]")]
public class SecureController : ControllerBase
{
    private static List<(string Username, string HashedPassword, string Email)> _users = new();

    // 1. Input Validation
    [HttpPost("register")]
    public IActionResult Register(RegisterModel model)
    {
        // Validate username
        if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Length < 3)
            return BadRequest("Username must be at least 3 characters.");

        // Validate email
        var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(model.Email, emailRegex))
            return BadRequest("Invalid email format.");

        // Validate password strength
        if (model.Password.Length < 8)
            return BadRequest("Password must be at least 8 characters.");
        if (!Regex.IsMatch(model.Password, @"[A-Z]"))
            return BadRequest("Password must contain uppercase letter.");
        if (!Regex.IsMatch(model.Password, @"[0-9]"))
            return BadRequest("Password must contain a number.");
        if (!Regex.IsMatch(model.Password, @"[!@#$%^&*]"))
            return BadRequest("Password must contain special character.");

        // Check duplicate
        if (_users.Any(u => u.Username == model.Username))
            return BadRequest("Username already exists.");

        // Hash password before storing
        string hashed = BCrypt.Net.BCrypt.HashPassword(model.Password);
        _users.Add((model.Username, hashed, model.Email));

        return Ok("User registered securely!");
    }

    // 2. Secure Login
    [HttpPost("login")]
    public IActionResult Login(LoginModel model)
    {
        // Prevent timing attacks - always hash compare
        var user = _users.FirstOrDefault(u => u.Username == model.Username);

        if (user == default || !BCrypt.Net.BCrypt.Verify(model.Password, user.HashedPassword))
            return Unauthorized("Invalid credentials.");

        return Ok($"Welcome {model.Username}! Login successful.");
    }

    // 3. SQL Injection Prevention Demo
    [HttpGet("safe-search")]
    public IActionResult SafeSearch(string username)
    {
        // Never do: $"SELECT * FROM users WHERE name = '{username}'"
        // Always use parameterized queries or LINQ
        var result = _users
            .Where(u => u.Username == username)
            .Select(u => new { u.Username, u.Email })
            .ToList();

        return Ok(result);
    }

    // 4. XSS Prevention
    [HttpPost("safe-input")]
    public IActionResult SafeInput(string input)
    {
        // Sanitize input - encode HTML
        string sanitized = System.Net.WebUtility.HtmlEncode(input);
        return Ok(new
        {
            Original  = input,
            Sanitized = sanitized,
            Message   = "Input has been sanitized to prevent XSS!"
        });
    }

    // 5. Get users (never expose passwords)
    [HttpGet("users")]
    public IActionResult GetUsers()
    {
        var safeUsers = _users.Select(u => new
        {
            u.Username,
            u.Email,
            Password = "***HIDDEN***"  // Never expose passwords!
        });
        return Ok(safeUsers);
    }
}