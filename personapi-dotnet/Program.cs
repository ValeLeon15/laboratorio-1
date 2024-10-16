using personapi_dotnet.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using personapi_dotnet.Controllers.Api;


var builder = WebApplication.CreateBuilder(args);

// Repositorios


// Configuración de servicios
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<PersonasApiController>();
builder.Services.AddScoped<ProfesionesApiController>();
builder.Services.AddScoped<EstudiosApiController>();
builder.Services.AddScoped<TelefonosApiController>();


// Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Persona API", Version = "v1" });
});

builder.Services.AddDbContext<PersonaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Configurar Kestrel para que escuche en todas las interfaces
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(8080); // Cambia el puerto si es necesario
});

var app = builder.Build();

// Middleware para manejar excepciones
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    // Habilitar Swagger en cualquier entorno para pruebas
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    });

}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
