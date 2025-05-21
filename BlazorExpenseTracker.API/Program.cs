using BlazorExpenseTracker.Data;

var builder = WebApplication.CreateBuilder(args);

// Paso 1: Obtener connection string del appsettings.json
var sqlConnectionString = builder.Configuration.GetConnectionString("SQLConnection");

// Paso 2: Instanciar SqlConfiguration con ese connection string
var sqlConnectionConfiguration = new SqlConfiguration(sqlConnectionString);

// Paso 3: Registrar como singleton para que sea accesible en toda la app
builder.Services.AddSingleton(sqlConnectionConfiguration);

// Agregar servicios MVC, API, etc.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
