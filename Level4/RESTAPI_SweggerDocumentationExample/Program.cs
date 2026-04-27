using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title       = "Student API",
        Version     = "v1",
        Description = "A simple Student Management REST API",
        Contact     = new OpenApiContact
        {
            Name  = "Nikita",
            Email = "nikita@example.com"
        }
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student API v1");
    c.RoutePrefix = string.Empty; // Opens Swagger at root URL
});

app.UseAuthorization();
app.MapControllers();
app.Run();