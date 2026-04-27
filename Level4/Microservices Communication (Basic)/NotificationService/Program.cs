var builder2 = WebApplication.CreateBuilder(args);
builder2.Services.AddControllers();
var app2 = builder2.Build();
app2.UseAuthorization();
app2.MapControllers();
app2.Run();