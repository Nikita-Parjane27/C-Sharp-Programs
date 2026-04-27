// Extends Program 169 — add role-based access

// Controllers/AdminController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    // Only Admin role can access
    [HttpGet("dashboard")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminDashboard()
    {
        return Ok("Welcome Admin! Full access granted.");
    }

    // Only Manager role can access
    [HttpGet("reports")]
    [Authorize(Roles = "Manager")]
    public IActionResult ManagerReports()
    {
        return Ok("Manager Reports - Restricted Area.");
    }

    // Both Admin and User roles can access
    [HttpGet("profile")]
    [Authorize(Roles = "Admin,User")]
    public IActionResult UserProfile()
    {
        var username = User.Identity?.Name;
        return Ok($"Profile of: {username}");
    }

    // Anyone authenticated can access
    [HttpGet("public")]
    [Authorize]
    public IActionResult PublicData()
    {
        return Ok("Accessible to all logged-in users.");
    }
}