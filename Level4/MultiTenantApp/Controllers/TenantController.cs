using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TenantController : ControllerBase
{
    private readonly TenantService _tenantService;

    private static Dictionary<string, List<string>> _tenantData = new()
    {
        { "tenant1", new List<string> { "Tenant1-User1", "Tenant1-User2" } },
        { "tenant2", new List<string> { "Tenant2-User1", "Tenant2-User2" } },
        { "default", new List<string> { "Default-User1" } }
    };

    public TenantController(TenantService tenantService)
    {
        _tenantService = tenantService;
    }

    [HttpGet("info")]
    public IActionResult GetTenantInfo()
    {
        string tenant = _tenantService.GetCurrentTenant();
        return Ok(new
        {
            TenantId = tenant,
            Message  = $"You are accessing data for tenant: {tenant}"
        });
    }

    [HttpGet("data")]
    public IActionResult GetTenantData()
    {
        string tenant = _tenantService.GetCurrentTenant();
        if (!_tenantData.ContainsKey(tenant))
            return NotFound($"No data found for tenant: {tenant}");

        return Ok(new
        {
            TenantId = tenant,
            Data     = _tenantData[tenant]
        });
    }
}