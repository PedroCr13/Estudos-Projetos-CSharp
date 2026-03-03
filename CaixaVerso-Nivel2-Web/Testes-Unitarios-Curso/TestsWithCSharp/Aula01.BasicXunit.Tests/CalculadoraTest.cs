using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 /*
    Convenção para organização: criar um projeto separado com mesmo nome para testes
    
    Adicionar o projeto principal como referência. No projeto de testes, em Dependêncies setar.
 */

namespace Aula01.BasicXunit.Tests
{
    public class CalculadoraTest
    {
        // maioria das vezes o metodo de teste será um void (sem retorno)
        // metodo deve ser explicito na assinatura o que ele está testando
        // padrão: dividir nome em tres partes:
        // primeiro elemento: nome unidade que esta testando
        // segundo: contexto do teste (o que esta testando?)
        // terceiro: o resultado esperado
        // partes do nome separadas por _
        // NomeDaUnidade_Contexto_ResutladoEsperado
        [Fact]
        public void Calculadora_Somar_SomaDosValores()
        {
            // Separar o código em três blocos: Padrão AAA (triplo A)
            // Arrange: Definir o estado inicial para o teste, variáveis, inicialização
            // Act (ação): onde será escrito o que será testado
            // Assert: o que vai comprovar o resultado, provar que deu certo (resultado foi esperado?)

            // Arrange - O que precisa para testar o metodo?
            Calculadora calc = new Calculadora();

            // Act - o que será testado?
            int resultado = calc.Somar(2, 2);

            // Assert - a variável resultado terá que valor? Comparar com o testado com o esperado

            // equal: retorna booleano
            Assert.Equal(4, resultado);
        }

        // Realizar mais de um teste de valores em um único teste (usando [Theory])

        [Theory]  // Theory deve vir acompanhado de InLineData com os valores a testar e resultado esperado
        [InlineData(2, 2, 4)] // o que será testado e resultado esperado
        [InlineData(3, 2, 5)]
        [InlineData(1, 5, 6)]
        public void Calculadora_Somar_SomaVariosValores(int a, int b, int resultadoEsperado)
        {
            // Arrange
            Calculadora calc = new Calculadora();

            // Act
            int resultado = calc.Somar(a, b);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
