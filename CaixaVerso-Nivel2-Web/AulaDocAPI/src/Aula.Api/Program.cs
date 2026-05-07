/*
    Swagger permite documentar a API
    - customizar informações
    - Customizar comentários XML
    - Documentar autenticação e autorização
    - Documentar versionamento de API

    baseada no padrão OpenAPI
 */

using Aula.Api.Configuration;
using Aula.Api.Middlewares;
using Aula.Application.Requests;
using Aula.Application.UseCases;
using Aula.Application.Validators;
using FluentValidation;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.

// Registra a dependência com ciclo de vida scoped (uma instância por requisição HTTP).
// O container de DI vê essa necessidade e injeta automaticamente a implementação registrada (CriarAlunoValidator).
builder.Services.AddScoped<IValidator<CriarAlunoRequest>, CriarAlunoValidator>();
builder.Services.AddScoped<ICriarAlunoUseCase, CriarAlunoUseCase>();

builder.Services.AddHealthChecks();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Documentação
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();

var app = builder.Build();

app.UseRouting();
// expor endpoints documentação
app.UseSwagger();
app.UseSwaggerUI();

// Leitura é feita em ordem de declaração:

app.UseHttpsRedirection();

var loggerFactory = builder.Services?.BuildServiceProvider().GetRequiredService<ILoggerFactory>();

app.UseCustomLogs(loggerFactory, builder.Configuration);

app.UseAuthorization();

app.UseMiddleware<ErrorMiddleware>();

// testar se a API está funcionando:
app.UseEndpoints(endpoints =>
{ 
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health", new HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});

app.MapControllers();

app.Run();
