using Application.Interface;
using Application.UseCase;
using Infrastructure;
using Infrastructure.Command;
using Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Windows.Input;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CineContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=rokopop2;Trusted_Connection=True;TrustServerCertificate=True;Persist Security Info=true");
});


builder.Services.AddTransient<ICineService, CineService>();
builder.Services.AddTransient<ICineCommand, CineCommand>();
builder.Services.AddTransient<ICineQuery, CineQuery>();

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
