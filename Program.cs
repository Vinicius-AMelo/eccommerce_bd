using E_Commerce.Context;
using E_Commerce.Interfaces;
using E_Commerce.Models;
using E_Commerce.Repositories;
using E_Commerce.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string myStringConnection = $"Host=azurestudy.brazilsouth.cloudapp.azure.com;Username=vini;Password=vini;Database=vini";
builder.Services.AddDbContext<StoreContext>(options => options.UseNpgsql(myStringConnection));
builder.Services.AddScoped(typeof(IUpdateService<>), typeof(UpdateService<>));
builder.Services.AddScoped<IProductRepository<Product>, ProductRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();