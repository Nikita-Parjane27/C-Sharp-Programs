using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet("login")]
    public IActionResult Login()
    {
        var props = new AuthenticationProperties
        {
            RedirectUri = "/api/auth/profile"
        };
        return Challenge(props, "Google");
    }

    [HttpGet("profile")]
    [Authorize]
    public IActionResult Profile()
    {
        var name  = User.FindFirst(ClaimTypes.Name)?.Value;
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        return Ok(new
        {
            Message = "Logged in via Google OAuth!",
            Name    = name,
            Email   = email
        });
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok("Logged out successfully.");
    }
}