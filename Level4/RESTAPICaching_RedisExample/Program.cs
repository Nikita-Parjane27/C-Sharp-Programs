var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName  = "MyApp_";
});

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.Run();
