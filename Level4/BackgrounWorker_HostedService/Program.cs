// Program.cs
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddHostedService<BackgroundWorkerService>(); // Register worker

var app = builder.Build();
app.MapControllers();
app.Run();
