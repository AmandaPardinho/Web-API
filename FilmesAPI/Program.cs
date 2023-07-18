using FilmesAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//O builder de conexão abaixo só funciona no Program.cs se estivermos usando o Visual Studio 2022
//ConnectionStrings => 
//ConnectionStrings completa => ("Data Source=DESKTOP-MIHQT5G;Initial Catalog=Filmes_API;Integrated Security=False;User ID=sa;Password=amanda03;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"));
//Alguns servidores só aceitam a string completa
builder.Services.AddDbContext<FilmeContext>(opts => opts.UseSqlServer
("Data Source=DESKTOP-MIHQT5G;Initial Catalog=Filmes_API;User ID=sa;Password=amanda03"));

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
