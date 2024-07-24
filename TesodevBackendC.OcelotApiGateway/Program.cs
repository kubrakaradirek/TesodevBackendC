using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Ocelot yap�land�rmas�n� ekleyin
builder.Configuration.AddJsonFile("ocelot.json");

builder.Services.AddOcelot();

// Swagger yap�land�rmas�n� ekleyin
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ocelot API Gateway", Version = "v1" });
});

// Di�er servisleri ekleyin
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Swagger'� kullan�n
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ocelot API Gateway V1");
    c.RoutePrefix = string.Empty;
});

// Ocelot'u kullan�n
app.UseOcelot().Wait();

// Varsay�lan route
app.MapGet("/", () => "Hello World!");

// HTTPS y�nlendirme ve yetkilendirme
app.UseHttpsRedirection();
app.UseAuthorization();

// Controller'lar� haritala
app.MapControllers();

app.Run();
