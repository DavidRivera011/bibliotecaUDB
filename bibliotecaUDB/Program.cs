using bibliotecaUDB.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Leemos la contrase�a desde la variable de entorno (App Service la inyecta autom�ticamente)
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

if (string.IsNullOrEmpty(dbPassword))
{
    // Opcional: si quieres permitir debug local sin variable de entorno, puedes asignar un valor temporal
    // dbPassword = "tuContrase�aLocal";
    throw new Exception("La variable de entorno DB_PASSWORD no est� configurada o no se puede leer.");
}

// Obtenemos el connection string y reemplazamos el placeholder por la contrase�a real
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                            .Replace("%DB_PASSWORD%", dbPassword);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(connectionString)
);

var app = builder.Build();

// Ejecutamos las migraciones autom�ticamente
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    ctx.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
