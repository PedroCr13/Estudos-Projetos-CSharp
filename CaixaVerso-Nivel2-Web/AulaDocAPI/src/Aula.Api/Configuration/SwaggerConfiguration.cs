using System.Reflection;

/*
    Classe criada para encapsular a configuração do Swagger
    mantendo a Program limpa.
*/

namespace Aula.Api.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            // adicionar informações adcionais sobre API:
           services.AddSwaggerGen(c =>
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

            return services;
        }
    }
}
