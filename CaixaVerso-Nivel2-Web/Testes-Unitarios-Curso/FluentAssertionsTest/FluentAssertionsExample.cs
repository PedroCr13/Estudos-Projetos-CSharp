using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

// Estrutura do teste: (AAA) Arrange, Act e Assert

/* 
 * Instalar Extensão FluentAssertions:
 * Clicar sobre Dependências > botão direito > Manager NuGets packages
 * Brownse > instalar FluentAssertions > install
*/
namespace FluentAssertionsTest
{
    public class FluentAssertionsExample
    {
        // Comparando dois valores: (deve ser padrão Fluent: Should_Be_Equal)
        // Should be = deve ser
        [Fact]
        public void Test_String_Should_Be_Equal()
        {
            string esperado = "Hello, World!";
            string resultado = "Hello, World!";

            // XUnit:
            // Assert.Equal(esperado, resultado);

            // Com FluentAssertion: "resultado deve ser esperado"
            //resultado.Should().Be(esperado);

            // Com justificativa caso o testes falhe (parâmetro opcional because)
            resultado.Should().Be(esperado, "Hello, world! é o resultado esperado");
        }

        // Exemplo verificar se uma string inicia com determinado caracter
        [Fact]
        public void Teste_String_Should_Start_With()
        {
            string resultado = "FluentAssertions";

            resultado.Should().StartWith("Fluent"); 
            resultado.Should().EndWith("Assertions");
            // caso uma verificação falhe, o teste como todo falha
        }

        // Teste com números
        [Fact]
        public void Test_Number_Should_Be_Greater_Than()
        {
            int resultado = 10;

            resultado.Should().BeGreaterThan(7);
            resultado.Should().BeGreaterThanOrEqualTo(10);
        }

        // Comparando tipos
        [Fact]
        public void Test_Objetct_Should_Be_Type()
        {
            var resultado = new Cliente();

            resultado.Should().BeOfType(typeof(Cliente));
        }

        // Comparando datas
        [Fact]
        public void Test_Date_Should_Be_After()
        { 
            DateTime resultado = new DateTime(2024, 1, 1);

            // resultado.Should().BeAfter(DateTime.MinValue);
            // resultado.Should().BeBefore(DateTime.MaxValue);

            // data em intervalo (pemite combinação com .And)
            resultado.Should().BeAfter(new DateTime(2023, 12, 1))
                .And.BeBefore(new DateTime(2026, 2, 1));
        }

        [Fact]
        public void Test_String_Should_Be_Empty()
        {
            string value = string.Empty;

            value.Should().BeEmpty();

            //string.IsNullOrEmpty(value).Should().BeTrue();
        }
    }
}

public class Cliente
{ 
    
}