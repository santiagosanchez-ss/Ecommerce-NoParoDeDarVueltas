using Ecommerce.Repository.DBContext;
using Microsoft.EntityFrameworkCore;

using Ecommerce.Repository.Contract;
using Ecommerce.Repository.Implementation;

using Ecommerce.Utilities;
using Microsoft.Extensions.DependencyInjection;

using Ecommerce.Service.Contract;
using Ecommerce.Service.Implementation;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<NoParoDeDarVueltasDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSql"));
});
//
builder.Services.AddScoped(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));
//
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorio>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();
builder.Services.AddScoped<IVentaServicio, VentaServicio>();
builder.Services.AddScoped<IDashboardServicio, DashboardServicio>();


//COFIGURACION PARA PODER USAR LA API EN CUALQUIER DOMINIO 
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
