
global using BlazorEcommerce.Server.Modelos;
global using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BlazorEcommerce.Server.Utilidades;
using BlazorEcommerce.Server.Servicios.PersonaSV;
using BlazorEcommerce.Server.Repositorios;
using BlazorEcommerce.Server.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<DbtiendaBlazorContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


builder.Services.AddTransient(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorio>();

builder.Services.AddScoped<IPersonaServicio, PersonaServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();
builder.Services.AddScoped<IVentaServicio, VentaServicio>();
builder.Services.AddScoped<IDashboardServicio, DashboardServicio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
