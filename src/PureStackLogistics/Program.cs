using Microsoft.EntityFrameworkCore;
using PureStackLogistics.Data;
using PureStackLogistics.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Add Services (Dependency Injection)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Setup In-Memory Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("PureStackDb"));

// 3. Register Business Services
builder.Services.AddScoped<IInventoryService, InventoryService>();

var app = builder.Build();

// 4. Configure Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
