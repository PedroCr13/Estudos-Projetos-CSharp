using IntegrationDemo.Context;
using IntegrationDemo.Models;
using IntegrationDemo.Repositories;
using Microsoft.EntityFrameworkCore;

/*
    Teste de Ingtegração:
    Diferente do teste unitário em que é testada somente uma classe as dependências desta são mockadas (simualadas)
    no teste de integração as dependências também são testadas para verificar se a classe lida com os retornas das
    dependâncias como o esperado.
 
 */

namespace IntegrationDemoTests
{
    public class ProductRespositoryTest
    {
        // Propriedade compartilhada com todos os testes (contexto do banco de dados)
        private DbContextOptions<AppDbContext> _dbContextOptions;

        public ProductRespositoryTest()
        {
            // configurando banco de dados em memória:
            _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                // extensão EntityFrameWorkInMemory 
                .UseInMemoryDatabase(databaseName: "TestDataBase")
                .Options;
        }

        // teste adicionando um produto usando o banco de dados
        // Entre aplicativo principal e BD
        [Fact]
        public void AddProduct_ShouldAddProductToDataBase()
        {
            // Arrange
            using var context = new AppDbContext(_dbContextOptions);
            var repository = new ProductRepository(context);
            var product = new Product { Name = "Test Product", Price = 10.0m };

            // Act
            repository.Add(product);

            // Assert
            var savedProduct = context.Products.FirstOrDefault(p => p.Name == "Test Product");

            // Verificações no produto salvo (retornado pelo banco dados)
            Assert.NotNull(savedProduct);
            Assert.Equal("Test Product", savedProduct.Name);
            Assert.Equal(10.0m, savedProduct.Price);
        }

        [Fact]
        public void GetAll_ShouldReturnAllProducts()
        {
            // Arrange
            using var context = new AppDbContext(_dbContextOptions);
            
            // Reseta o banco em memória, caso não queira os dados incluídos em outro teste
            context.Database.EnsureDeleted();
            
            context.Products.Add(new Product { Name = "Product 1", Price = 5.0m});
            context.Products.Add(new Product { Name = "Product 2", Price = 15.0m});
            context.SaveChanges();
            var repository = new ProductRepository(context);

            // Act
            var products = repository.GetAll();

            // Assert
            // Verifica se os dois produtos foram salvos no banco
            Assert.Equal(2, products.Count());
            Assert.Contains(products, p => p.Name == "Product 1");
            Assert.Contains(products, p => p.Name == "Product 2");
        }
    }
}
