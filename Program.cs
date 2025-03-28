using GestionDeReservas.Application.Features.Interfaces;
using GestionDeReservas.Domain;
using GestionDeReservas.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

builder.Services.AddTransient<IReservaRepository, ReservaRepository>();
builder.Services.AddTransient<IReservaHorarioRepository, ReservaHorarioRepository>();
builder.Services.AddTransient<IServicioRepository, ServicioRepository>();
builder.Services.AddTransient<IHorarioRepository, HorarioRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactFrontend", policy =>
    {
        policy.WithOrigins("https://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()
              .SetIsOriginAllowedToAllowWildcardSubdomains();
    });
});

var app = builder.Build();

app.UseCors("ReactFrontend");

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    dbContext.Database.Migrate();

    InitializeData(dbContext);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}




app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

void InitializeData(AppDbContext dbContext)
{
    if (!dbContext.Servicio.Any())
    {
        dbContext.Servicio.AddRange(
            new Servicio { Descripcion = "Peluqueria La Mejor" },
            new Servicio { Descripcion = "Peluqueria Somos Todos" },
            new Servicio { Descripcion = "Lavanderia Juan" },
            new Servicio { Descripcion = "Hotelería Misiones" }
        );
    }

    if (!dbContext.Horario.Any())
    {
        dbContext.Horario.AddRange(
            new Horario { Hora = new TimeSpan(10, 0, 0) },
            new Horario { Hora = new TimeSpan(11, 0, 0) },
            new Horario { Hora = new TimeSpan(12, 0, 0) },
            new Horario { Hora = new TimeSpan(13, 0, 0) },
            new Horario { Hora = new TimeSpan(14, 0, 0) },
            new Horario { Hora = new TimeSpan(15, 0, 0) },
            new Horario { Hora = new TimeSpan(16, 0, 0) },
            new Horario { Hora = new TimeSpan(17, 0, 0) },
            new Horario { Hora = new TimeSpan(18, 0, 0) }
        );
    }

    dbContext.SaveChanges();
}