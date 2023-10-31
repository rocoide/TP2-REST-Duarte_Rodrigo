using Application.Interface.Funciones;
using Application.Interface.Peliculas;
using Application.Interface.Salas;
using Application.Interface.Tickets;
using Application.UseCase;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CineContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=rokopop2DB;Trusted_Connection=True;TrustServerCertificate=True;Persist Security Info=true");
});


builder.Services.AddTransient<IPeliculaService, PeliculaService>();
builder.Services.AddTransient<IPeliculaCommand, PeliculaCommand>();
builder.Services.AddTransient<IPeliculaQuery, PeliculaQuery>();

builder.Services.AddTransient<IFuncionService, FuncionService>();
builder.Services.AddTransient<IFuncionCommand, FuncionCommand>();
builder.Services.AddTransient<IFuncionQuery, FuncionQuery>();

builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddTransient<ITicketCommand, TicketCommand>();
builder.Services.AddTransient<ITicketQuery, TicketQuery>();

builder.Services.AddTransient<ISalaQuery, SalaQuery>();

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
