using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMemoryCache _cache;
    private static List<Product> _products;

    public ProductController(IMemoryCache cache)
    {
        _cache = cache;

        // Generate large dataset
        if (_products == null)
        {
            _products = new List<Product>();
            for (int i = 1; i <= 10000; i++)
                _products.Add(new Product
                {
                    Id       = i,
                    Name     = $"Product {i}",
                    Price    = i * 10.5,
                    Category = i % 2 == 0 ? "Electronics" : "Clothing"
                });
        }
    }

    // Normal endpoint - no optimization
    [HttpGet("normal")]
    public IActionResult GetNormal()
    {
        var sw = Stopwatch.StartNew();
        var result = _products.ToList();
        sw.Stop();
        return Ok(new { Count = result.Count, TimeTakenMs = sw.ElapsedMilliseconds, Data = result.Take(10) });
    }

    // Cached endpoint - with memory cache
    [HttpGet("cached")]
    public IActionResult GetCached()
    {
        var sw = Stopwatch.StartNew();

        if (!_cache.TryGetValue("products", out List<Product> cached))
        {
            cached = _products.ToList();
            _cache.Set("products", cached, TimeSpan.FromMinutes(5));
        }

        sw.Stop();
        return Ok(new { Count = cached.Count, TimeTakenMs = sw.ElapsedMilliseconds, Data = cached.Take(10) });
    }

    // Paginated endpoint - high performance
    [HttpGet("paginated")]
    public IActionResult GetPaginated(int page = 1, int pageSize = 10)
    {
        var sw = Stopwatch.StartNew();

        var result = _products
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        sw.Stop();
        return Ok(new
        {
            Page        = page,
            PageSize    = pageSize,
            TotalCount  = _products.Count,
            TimeTakenMs = sw.ElapsedMilliseconds,
            Data        = result
        });
    }

    // Filtered endpoint
    [HttpGet("filter")]
    public IActionResult GetFiltered(string category)
    {
        var sw = Stopwatch.StartNew();

        var result = _products
            .Where(p => p.Category == category)
            .Take(10)
            .ToList();

        sw.Stop();
        return Ok(new { Count = result.Count, TimeTakenMs = sw.ElapsedMilliseconds, Data = result });
    }
}