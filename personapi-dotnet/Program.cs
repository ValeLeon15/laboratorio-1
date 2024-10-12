var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Agregar SwaggerGen
builder.Services.AddEndpointsApiExplorer(); //permite a swagger explorar los endpoints de la aplicación
builder.Services.AddSwaggerGen();  //Registra el generador de Swagger


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
