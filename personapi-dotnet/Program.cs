using personapi_dotnet.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using personapi_dotnet.Models.Interfaces;
using personapi_dotnet.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IProfesionRepository, ProfesionRepository>();
builder.Services.AddScoped<IEstudioRepository, EstudioRepository>();
builder.Services.AddScoped<ITelefonoRepository, TelefonoRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PersonaDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("PersonaDbContext"));
});


// Agregar SwaggerGen
builder.Services.AddEndpointsApiExplorer(); //permite a swagger explorar los endpoints de la aplicación
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Persona API", Version = "v1" });
});  //Registra el generador de Swagger

builder.Services.AddDbContext<PersonaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Home/Error");
}
else //usar swagger en desarrollo
{
    // Habilitar Swagger solo en entorno de desarrollo
    app.UseSwagger(); // Habilitar middleware de Swagger
    app.UseSwaggerUI(c => //Habilitar interfaz de usuario de Swagger
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty; // Swagger UI en la raíz de la app
    });
}



app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
