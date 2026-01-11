using Biblioteca.Api.DTOs;
using Biblioteca.Api.Models.Context;
using Biblioteca.Api.Models.Entities;
using Biblioteca.Api.Service;
using Biblioteca.Api.Validators;
using FluentValidation;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Livro>("Livros");
modelBuilder.EntitySet<Autor>("Autores");
modelBuilder.EntitySet<Editora>("Editoras");

// Add services to the container.

builder.Services.AddControllers()
    .AddOData(opt => opt
        .AddRouteComponents("odata", modelBuilder.GetEdmModel())
        .Select()
        .Filter()
        .OrderBy()
        .Expand()
        .Count()
        .SetMaxTop(10));

// Configuração do EF Core + MySQL
builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 40)) 
));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Registro de serviços para entrega da instância correta pelo Asp.Net quando pedida:

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<LivrosService>();
builder.Services.AddScoped<AutoresService>();

builder.Services.AddScoped<IValidator<AutorDTO>, AutorDtoValidator>();
builder.Services.AddScoped<IValidator<LivroDTO>, LivroDtoValidator>();
builder.Services.AddScoped<IValidator<EditoraDTO>, EditoraDtoValidator>();

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
