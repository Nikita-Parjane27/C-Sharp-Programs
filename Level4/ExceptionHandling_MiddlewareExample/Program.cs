var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>(); // Register here
app.UseAuthorization();
app.MapControllers();
app.Run();