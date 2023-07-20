using System.Reflection;
using FilmesAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//O builder de conex�o abaixo s� funciona no Program.cs se estivermos usando o Visual Studio 2022
//ConnectionStrings => 
////ConnectionStrings completa => ("Data Source=DESKTOP-MIHQT5G;Initial Catalog=Filmes_API;Integrated Security=False;User ID=sa;Password=amanda03;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"));
////Alguns servidores s� aceitam a string completa
//abaixo, dois modos de fazer a conex�o com o banco de dados:
//builder.Services.AddDbContext<FilmeContext>(opts => opts.UseSqlServer
//("Data Source=DESKTOP-MIHQT5G;Initial Catalog=Filmes_API;User ID=sa;Password=amanda03"));
builder.Services.AddDbContext<FilmeContext>(opts => opts.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("FilmeConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "FilmesAPI", Version = "v1" });
  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
  c.IncludeXmlComments(xmlPath);
});


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
