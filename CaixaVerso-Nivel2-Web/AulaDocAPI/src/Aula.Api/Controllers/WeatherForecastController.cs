using Microsoft.AspNetCore.Mvc;

namespace Aula.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// EndPoint para retornar a previsão do tempo de hoje e dos próximos 5 dias
        /// </summary>
        /// <response code="200">Lista de previsões para os próximos dias</response>
        /// <response code="404">Estamos sem previsão do tempo</response>
        // Obs: adicionar propety group no csproj: <GenerateDocumentationFile>true</GenerateDocumentationFile>
        // e também na program em SwaggerGer adicionar inclusão do XML
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
  
            // criado um midleware que encapsula o try catch e mensagem de retono em caso de exceção
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return Ok(result);
        }
    }
}
