public class TenantService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TenantService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetCurrentTenant()
    {
        var request = _httpContextAccessor.HttpContext?.Request;
        if (request != null && request.Headers.TryGetValue("X-Tenant-ID", out var tenantId))
            return tenantId.ToString();
        return "default";
    }
}