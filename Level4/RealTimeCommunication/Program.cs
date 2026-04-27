var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.MapHub<ChatHub>("/chatHub"); // Map SignalR hub
app.MapControllers();
app.Run();

