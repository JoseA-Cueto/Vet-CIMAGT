using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Vet_CIMAGT.Data;
using Vet_CIMAGT.Mapping;
using Vet_CIMAGT.ServiceExtensions;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Agregar configuración de AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 2️⃣ Configurar servicios de controladores
builder.Services.AddControllers();

// 3️⃣ Configurar Swagger (documentación de API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 4️⃣ Configurar conexión a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 5️⃣ Configurar autenticación con JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            ValidateLifetime = true
        };
    });

// 6️⃣ Agregar autorización
builder.Services.AddAuthorization();

// 7️⃣ Registrar servicios personalizados (Extensiones de servicio)
builder.Services.AddWebServices();

// Agregar servicios CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin() // Permite cualquier origen (en desarrollo)
              .AllowAnyMethod() // Permite cualquier método (GET, POST, etc.)
              .AllowAnyHeader(); // Permite cualquier cabecera
    });
});

// Leer los puertos desde appsettings.json
var httpPort = builder.Configuration["AppSettings:Ports:Http"];
var httpsPort = builder.Configuration["AppSettings:Ports:Https"];

// Fijar los puertos
builder.WebHost.UseUrls($"http://localhost:{httpPort}", $"https://localhost:{httpsPort}");

var app = builder.Build();

// 9️⃣ Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 1️⃣0️⃣ Usar CORS
app.UseCors("AllowAllOrigins");

// 1️⃣1️⃣ Habilitar autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();


