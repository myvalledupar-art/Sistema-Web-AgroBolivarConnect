using Microsoft.EntityFrameworkCore;
using backend.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Forzar que siempre prenda en el 5071
builder.WebHost.UseUrls("http://localhost:5071");

// Base de datos
builder.Services.AddDbContext<AgroBolivarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Arreglo del Swagger
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- CORS ARREGLADO ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// --- ESTA ES LA LLAVE ---
app.UseCors("PermitirTodo");

app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "AgroBolivar Connect - API Activa");

app.Run();