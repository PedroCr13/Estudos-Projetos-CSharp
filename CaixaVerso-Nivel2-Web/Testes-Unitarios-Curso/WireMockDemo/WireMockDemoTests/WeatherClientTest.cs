using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMockDemo;

/*
    WireMock.Net: (biblioteca)
    Simula o retorno de uma API externa (servidor HTTP)
    Permite testar se o sistema está se comportando da forma planejada
    de acordo com o retorno da API que foi consultada.
    (teste de integração) 
    Permite "mokar" o retorno de uma API elinando a necessidade de conexões 
    constantes com serviços externos.

    Instalar extensão WiewMock.net pelo Gerenciador de pacotes NuGet
    também neste exemplo foi usada a extensão FluentAssertions)
*/

namespace WireMockDemoTests
{
    public class WeatherClientTest : IDisposable
    {
        // WireServer (já é do pacote WireMock)
        private readonly WireMockServer _server;

        public WeatherClientTest()
        {
            // inicia o servidor ficticio
            _server = WireMockServer.Start();
        }

        public void Dispose()
        {
            _server.Stop();
            // retira o servidor da memória
            _server.Dispose();
        }

        // Metodo para testar se a previsão do tempo obtida na API externa 
        // é a esperada
        [Fact]
        public void GetWeather_ShouldReturnExpectedWeatherData()
        {
            // Definindo a resposta do mock:
            _server
                // given está criando uma rota http get no servidor
                .Given(Request.Create().WithPath("/weather").UsingGet())
                .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-type", "application/json")
                // corpo do JSON de retorno:
                .WithBody(@"{ ""temperature"": ""25"", ""condition"": ""Sunny"" }"));

            // URL ficticia do WireMock
            var baseUrl = _server.Urls[0];

            // Instanciação do cliente do metódo que faz a requisição para URL ficticia
            var client = new WeatherClient(baseUrl);

            // cliente faz chamada a URL da API
            var weatherData = client.GetWeather();

            // Asserções:
            Assert.Equal("25", weatherData.Temperature);
            Assert.Equal("Sunny", weatherData.Condition);
        }
    }
}
