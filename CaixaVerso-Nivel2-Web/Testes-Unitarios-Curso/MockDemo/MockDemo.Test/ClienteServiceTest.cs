using FluentAssertions;
using MockDemo.Interfaces;
using MockDemo.Models;
using MockDemo.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Instalar a dependência MOQ (pacote NuGet) 
    Referenciar projeto de testes para o projeto principal.
    MOQ é uma extensão da Microsoft
    Da classe ClienteService serão testados os metodos ObterTodos() e o Adicionar()
    ambos dependem da classe ClienteRepository (a qual será feito mock)
    Também foi usada extensão FluentAssertions
*/

namespace MockDemo.Test
{
    public class ClienteServiceTest
    {
        // testar se ao adicionar um cliente ele válido
        // blocos do teste: convensão triplo A: Arrange, Act e Assert
        [Fact]
        public void Adicionar_ClienteValido_ClienteAdicionado()
        {
            // Arange (organização do teste, variáveis, inicializações)

            // Mock simulando o clienteRepository:
            Mock<IClienteRepository> clienteRepository = new();

            var clienteService = new ClienteService(clienteRepository.Object); // adicionar .Object
            var cliente = new Cliente("Pedro", "Lopes", new DateTime(1990, 05, 01), "pedro@lopes.com");

            // Act (o que será feito)
            clienteService.Adicionar(cliente);

            // Assert (resultado esperado)
            Assert.True(cliente.EhValido());

            // verificar se um metodo da dependencia clienteRepository foi chamado ao menos uma vez:
            // usando Verify do MOQ
            clienteRepository.Verify(x => x.Adicionar(cliente), Times.Once);

            // Verificar se o Adicionar do objeto mocado nunca foi chamado:
            // clienteRepository.Verify(x => x.Adicionar(cliente), Times.Never);
        }

        [Fact]
        public void Adicionar_ClienteValido_ClienteInvalido()
        {
            // Mock simulando o clienteRepository:
            Mock<IClienteRepository> clienteRepository = new();

            var clienteService = new ClienteService(clienteRepository.Object);

            // cliente sem nome e sem email para falhar:
            var cliente = new Cliente("", "Lopes", new DateTime(1990, 05, 01), "");

            clienteService.Adicionar(cliente);

            Assert.True(cliente.EhValido());

            // verificar se um metodo da dependencia clienteRepository foi chamado ao menos uma vez:
            // usando Verify do MOQ
            clienteRepository.Verify(x => x.Adicionar(cliente), Times.Once);
        }

        // MOQ permite simulacao de retornos da classe simulada:
        [Fact]
        public void ObterTodos_RetorarTodosOsClientes()
        {
            // Arange:
            var cliente1 = new Cliente("Pedro", "Lopes", new DateTime(1990, 05, 01), "pedro@lopes.com");
            var cliente2 = new Cliente("Joao", "Silva", new DateTime(1980, 05, 01), "joao@silva.com");

            var listaBanco = new List<Cliente>
            {
                cliente1,
                cliente2
            };

            Mock<IClienteRepository> clienteRepository = new();
            var clienteService = new ClienteService(clienteRepository.Object);

            // configurar objeto mokado para quanto chamado metodo ObterTodos
            // retornar a lista de clientes (ambiente comportamento controlado)
            clienteRepository.Setup(x => x.ObterTodos())
                .Returns(listaBanco);

            // Act
            var result = clienteService.ObterTodos();

            // Assert (usando FluentAssertions para verificar se retornou 2 clientes)
            result.Should().HaveCount(2);

            // verificar se ObterTodos() foi chamado ao menos uma vez
            clienteRepository.Verify(x => x.ObterTodos(), Times.Once);
        }
    }
}
