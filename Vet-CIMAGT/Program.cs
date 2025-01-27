using Microsoft.EntityFrameworkCore;
using Vet_CIMAGT.Data;
using Vet_CIMAGT.Mapping;
using AutoMapper;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Agregar configuración de base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar Swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();  // Esto es necesario para usar Swagger
builder.Services.AddSwaggerGen();  // Agregar el generador de Swagger

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Habilitar Swagger en el entorno de desarrollo
    app.UseSwaggerUI();  // Habilitar la interfaz de usuario de Swagger (UI)
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
