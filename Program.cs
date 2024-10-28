using Microsoft.EntityFrameworkCore;
using ApiEmpresa.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? cadena = builder.Configuration.GetConnectionString("DefaultConnection") ?? "otracadena";

builder.Services.AddControllers();
// Cambia UseSqlServer a UseMySql para utilizar MySQL
builder.Services.AddDbContext<Conexiones>(opt =>
    opt.UseMySql(cadena, new MySqlServerVersion(new Version(8, 0, 21)))); // Ajusta la versión según tu instalación

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
