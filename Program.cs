using E_Commerce.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string myStringConnection = $"Host=azurestudy.brazilsouth.cloudapp.azure.com;Username=vini;Password=vini;Database=vini";
builder.Services.AddDbContext<StudyContext>(options => options.UseNpgsql(myStringConnection));

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