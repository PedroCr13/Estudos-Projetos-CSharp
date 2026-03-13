using CodeCoverageDemo;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
