using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

[ApiController]
[Route("api/[controller]")]
public class CacheController : ControllerBase
{
    private readonly IDistributedCache _cache;
    public CacheController(IDistributedCache cache) { _cache = cache; }

    [HttpGet("set")]
    public async Task<IActionResult> SetCache()
    {
        var data = new { Name = "Nikita", Role = "Student" };
        string json = JsonSerializer.Serialize(data);

        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        await _cache.SetStringAsync("userInfo", json, options);
        return Ok("Data cached for 5 minutes.");
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetCache()
    {
        string cached = await _cache.GetStringAsync("userInfo");
        if (cached == null) return NotFound("Cache expired or not set.");
        return Ok(cached);
    }

    [HttpDelete("remove")]
    public async Task<IActionResult> RemoveCache()
    {
        await _cache.RemoveAsync("userInfo");
        return Ok("Cache cleared.");
    }
}