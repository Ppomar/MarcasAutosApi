using MarcasAutosApi.Data;
using MarcasAutosApi.Helpers.Infra;
using MarcasAutosApi.Repositories;
using MarcasAutosApi.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Configuración de servicios

// Registrar controladores
builder.Services.AddControllers();

// Swagger
builder.Services.AddSwaggerGen();

// DbContext con PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("MainConnectionString"));
});

// Inyección de dependencias
builder.Services.AddScoped<IMarcaAutoRepository, MarcaAutoRepository>();

#endregion Configuración de servicios

var app = builder.Build();

#region Configuración del pipeline

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MarcasAutos API v1");
        options.RoutePrefix = string.Empty;
    });   
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Migrar la base de datos al contenedor
app.MigrateDatabase();

#endregion

app.Run();
