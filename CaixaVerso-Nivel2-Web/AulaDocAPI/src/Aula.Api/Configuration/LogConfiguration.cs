using Serilog;
using Serilog.Events;

/*
 * 
 *  O New Relic é uma plataforma de observabilidade — ou seja, 
 *  uma ferramenta que ajuda você a monitorar e entender o comportamento da sua aplicação em produção. 
 *  Ele coleta métricas, logs e traces para dar visibilidade sobre desempenho, erros e uso da aplicação.
 *  
 *  SeriLog: coleta logs de eventos importantes para facilitar identificar falhas.
 *  
    Classe criada para encapsular a configurção de logs
    usando extensões: 
    <PackageReference Include="Serilog" Version="4.3.1" />
    <PackageReference Include="Serilog.AspNetCore" Version="10.0.0" />
    <PackageReference Include="Serilog.Sinks.Console" Version="6.1.1" />
    <PackageReference Include="Serilog.Sinks.NewRelic" Version="2.0.0" />
    <PackageReference Include="Serilog.Sinks.NewRelic.Logs" Version="1.3.0" />
*/

namespace Aula.Api.Configuration
{
    public static class LogConfiguration
    {
        public static void UseCustomLogs(this IApplicationBuilder app, ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            var newRelicSection = configuration.GetSection("NewRelic");
            var licenceKey = newRelicSection["LicenseKey"];

            // instancia configuração de logs:
            var loggerConfiguration = new LoggerConfiguration()
                // minimo de log information
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .WriteTo.Console()
                .WriteTo.NewRelicLogs(
                    applicationName: "Aula.Api", // quando olhar os logs indenticará aplicação de origem
                    licenseKey: licenceKey
                );

            Log.Logger = loggerConfiguration.CreateLogger();
            loggerFactory.AddSerilog(Log.Logger);
        }
    }
}
