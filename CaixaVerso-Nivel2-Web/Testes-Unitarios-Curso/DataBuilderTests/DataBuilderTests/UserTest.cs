using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

/*
    TestDataBuilder: Padrão de design que permite a construção de objetos
    complexos para testar de forma fluente e flexível
     
    Cria objetos com valores padrão 
    Não é uma extensão, é uma forma de escrever os construtores para gerar dados
*/

namespace DataBuilderTests
{
    public class UserTest
    {
        [Fact]
        public void CreateUser_ValidData_Sucess()
        {
            // Construção do usuário utilizado o builder:
            // cada metódo está retornando um UserBbuild
            var user = new UserBuilder()
                .WithUserName("José")
                .WithEmail("jose@silva.com")
                .WithDataOfBirth(new DateTime(1990, 5, 14))
                .Build();

            // Act
            // ...
            // Asserts
            // ...
        }
    }
}
