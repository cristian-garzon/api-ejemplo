using Gatitos.Context;
using Gatitos.Repository;
using Gatitos.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(s => s.SwaggerDoc("v1", new OpenApiInfo
{
    Version = "1.0",
    Title = "Api para los gatitos :3",
    Description = "que esperas, registra tu gatito en la api!!"
}));

//dependency injections
builder.Services.AddTransient<IGatitoContext, GatitoContext>();
builder.Services.AddTransient<IGatitoService, GatitoService>();
builder.Services.AddTransient<IPersonaRepository, PersonaRepository>();
builder.Services.AddTransient<IGatoRepository, GatoRepository>();

//conexion context
builder.Services.AddDbContext<GatitoContext>(option => option.UseSqlServer("Server=localhost,1433; Database=prueba; User ID=SA; Password=<camilo@cristian123>;"));

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
