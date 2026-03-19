using Aula.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Testes unitários são os testes mais baratos
    São investimentos de longo prazo, 
    úteis quando moficações no projeto para verificar se houve erros de funcionalidades
*/

namespace AulaDocApi.UnitTests.Services
{
    public class CalculadoraServiceTests
    {
        [Fact]
        public void Somar_DeveRetornarSomaCorreta()
        {
            // Arrange
            var numero1= 10;
            var numero2= 20;

            // Act
            var calculadoraService = new CalculadoraService();
            var soma = calculadoraService.Somar(numero1, numero2);

            // Assert (esperado, resultado)
            Assert.Equal(30, soma);    
        }

        [Theory]
        [InlineData(20, 10, 10)]
        [InlineData(10, 3, 7)]
        public void Subtrair_DeveRetornarSubtracaoCorretamente(int n1, int n2, int resultado)
        {

            var calculadoraService = new CalculadoraService();
            var subtracao = calculadoraService.Subtrair(n1, n2);

            Assert.Equal(resultado, subtracao);
        }
    }
}
