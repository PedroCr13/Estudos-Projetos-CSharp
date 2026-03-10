using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

/*
 *  Testando retorno de API
    Instalar extensão: Microsoft.AspNetCore.Mvc.Testing 
*/

namespace ApiDemoTests
{
    //  IClassFixture: os serviços que estiverem definios serão compartilhado entre todos os testes
    //  WebApplicationFactory irá rodar a API sem necessidade de executar o projeto principal.
    public class ValuesControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        // HttpClient: usando para fazer chamadas as APIs (legado)
        private readonly HttpClient _client;

        // na Program estão as configurações da API (entrypoint)
        // com base na program a WebApplicationFactory cria um cliente para consumir a API
        // o webapplication será compartilhado.
        public ValuesControllerTest(WebApplicationFactory<Program> factory)
        { 
           _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsValues()
        {
            // Act
            var response = await _client.GetAsync("/api/values");

            // Assert
            response.EnsureSuccessStatusCode(); // verifica se teve retorno de sucesso
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("value1", responseString);
            Assert.Contains("value2", responseString);
        }

        [Fact]
        public async Task Get_WithIdReturnsValue()
        {
            // act
            var response = await _client.GetAsync("/api/values/1");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("value1", responseString);
        }

        [Fact]
        public async Task Post_CreatesValue()
        {
            // Arrange:
            var content = new StringContent("\"value3\"", System.Text.Encoding.UTF8, "Application/json");

            // act
            var response = await _client.PostAsync("/api/values", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("value3", responseString);
        }
    }
}
