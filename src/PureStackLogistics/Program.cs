using Microsoft.EntityFrameworkCore;
using PureStackLogistics.Data;
using PureStackLogistics.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar DB en Memoria
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("LogisticsDb"));

// 2. Registrar el Servicio (Dependency Injection)
// El candidato debería asegurarse de que esto esté aquí o agregarlo
builder.Services.AddScoped<IInventoryService, InventoryService>();

var app = builder.Build();

app.MapGet("/", () => "PureStack Logistics API is running!");

app.Run();
