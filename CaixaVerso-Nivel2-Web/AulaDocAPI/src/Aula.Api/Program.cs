/*
    Swagger permite documentar a API
    - customizar informações
    - Customizar comentários XML
    - Documentar autenticação e autorização
    - Documentar versionamento de API

    baseada no padrão OpenAPI
 */

using Aula.Api.Middlewares;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Documentação
builder.Services.AddEndpointsApiExplorer();  

// adicionar informações adcionais sobre API:
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Aula.Api",
        Version = "v1",
        Description = "Aula demonstrando documentação de API",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Pedro Lopes",
            Email = "pedro@email.com.br"
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
}); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // expor endpoints documentação
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Leitura é feita em ordem de declaração:

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorMiddleware>();

app.MapControllers();

app.Run();
