using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly ILogger<UserController> _logger;

    public UserController(AppDbContext db, ILogger<UserController> logger)
    {
        _db     = db;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(string username, string email, string password)
    {
        if (await _db.Users.AnyAsync(u => u.Email == email))
            return BadRequest("Email already exists.");

        var user = new User
        {
            Username  = username,
            Email     = email,
            Password  = BCrypt.Net.BCrypt.HashPassword(password),
            Role      = "User",
            CreatedAt = DateTime.UtcNow
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        _logger.LogInformation("New user registered: {Email}", email);
        return Ok(new { Message = "Registered!", UserId = user.Id });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            _logger.LogWarning("Failed login for: {Email}", email);
            return Unauthorized("Invalid credentials.");
        }

        _logger.LogInformation("User logged in: {Email}", email);
        return Ok(new { Message = "Login successful!", user.Username, user.Role });
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _db.Users
            .Select(u => new { u.Id, u.Username, u.Email, u.Role, u.CreatedAt })
            .ToListAsync();
        return Ok(users);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null) return NotFound();
        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
        _logger.LogInformation("User deleted: {Id}", id);
        return Ok("User deleted!");
    }
}