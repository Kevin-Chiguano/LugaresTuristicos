using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configuraci�n del contexto de la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicios para controladores con vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Forzar HTTPS en producci�n
}

app.UseHttpsRedirection(); // Redireccionar a HTTPS
app.UseStaticFiles(); // Habilitar archivos est�ticos (CSS, JS, im�genes)

app.UseRouting(); // Configuraci�n de rutas

app.UseAuthorization(); // Autorizaci�n

// Configurar la ruta predeterminada
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
