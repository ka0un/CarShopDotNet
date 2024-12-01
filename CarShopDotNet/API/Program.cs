

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CarShopDotNet.Application.Services.Implementaion;
using CarShopDotNet.Application.Services.Interfaces;
using CarShopDotNet.Domain.Interfaces;
using CarShopDotNet.Infrastructure.Data;
using CarShopDotNet.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure SQLite connection
var projectDirectory = Directory.GetCurrentDirectory();
var databasePath = Path.Combine(projectDirectory, "CarShop.db");

// Configure SQLite with the full path
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite($"Data Source={databasePath}"));

// Dependency Injection
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();