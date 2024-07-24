using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Ocelot yapýlandýrmasýný ekleyin
builder.Configuration.AddJsonFile("ocelot.json");

builder.Services.AddOcelot();

// Swagger yapýlandýrmasýný ekleyin
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ocelot API Gateway", Version = "v1" });
});

// Diðer servisleri ekleyin
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Swagger'ý kullanýn
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ocelot API Gateway V1");
    c.RoutePrefix = string.Empty;
});

// Ocelot'u kullanýn
app.UseOcelot().Wait();

// Varsayýlan route
app.MapGet("/", () => "Hello World!");

// HTTPS yönlendirme ve yetkilendirme
app.UseHttpsRedirection();
app.UseAuthorization();

// Controller'larý haritala
app.MapControllers();

app.Run();
