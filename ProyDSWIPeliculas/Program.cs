using ProyDSWIPeliculas.DAO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1
builder.Services.AddScoped<PeliculasDAO>();
builder.Services.AddTransient<CarritoDAO>();
builder.Services.AddTransient<SalesDAO>();

// 2: Establecer el tiempo de duracion de las variables de sesión
builder.Services.AddSession(
    s => s.IdleTimeout = TimeSpan.FromMinutes(20));

var app = builder.Build();

// 3: Habilitar las variables de sesión
app.UseSession();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
