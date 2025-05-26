using BlazorExpenseTracker.Data;
using BlazorExpenseTracker.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 0. Configura CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorUI", policy =>
    {
        policy.WithOrigins("https://localhost:7271")  // URL donde corre UI Blazor
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Paso 1: Obtener connection string desde appsettings.json
var sqlConnectionString = builder.Configuration.GetConnectionString("SQLConnection");

// Paso 2: Registrar ApplicationDbContext con EF Core usando la cadena de conexión
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(sqlConnectionString)
);

// Paso 3: Registrar tus repositorios (por ejemplo CategoryRepository)
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Paso 4: Agregar servicios MVC, API, etc.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure el pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Aquí aplicas la política CORS:
app.UseCors("AllowBlazorUI");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
