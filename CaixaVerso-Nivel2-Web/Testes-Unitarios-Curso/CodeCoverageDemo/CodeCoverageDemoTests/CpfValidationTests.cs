using CodeCoverageDemo;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
    Boas práticas:

    Desenvolvimento guiado por testes (TDD)
    Refatoração continua
    Análise de risco e priorização (partes com maior impacto, criticos)
    Teste de regressão (novas funcionalidades não quebrem já existentes)
    Mocking (isolar partes do sistema) e Stubbing 
    Revisão de código e testes (cobertura e qualidade)
    Testes em diversos ambientes (navegadores, SOs)
    Treinamento e cultura de teste
    Métricas de cobertura
*/

namespace CodeCoverageDemoTests
{
    public class CpfValidationTests
    {
        // cada linha é um teste 
        [Theory]
        [InlineData("15231766607")]
        [InlineData("78246847333")]
        [InlineData("64184957307")]
        [InlineData("21681764423")]
        [InlineData("13830803800")]
        public void Cpf_ValidarMultiplisNumeros_TodosDevemSerValidados(string cpf)
        {
            // Arrange
            var cpfValidation = new CpfValidation();

            // Act and Assert
            cpfValidation.EhValido(cpf).Should().BeTrue();
        }

        [Theory]
        [InlineData("15231766")]
        [InlineData("1523176611111111")]
        [InlineData("1111")]
        public void Cpf_ValidarMultiplisNumeros_TodosDevemSerInvalidos(string cpf)
        {
            // Arrange
            var cpfValidation = new CpfValidation();

            // Act and Assert
            cpfValidation.EhValido(cpf).Should().BeFalse();
        }
    }
}
