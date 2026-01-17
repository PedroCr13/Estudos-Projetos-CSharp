using Xunit;

namespace Ada.Loja.Tests
{
   public class PedidoTest
    {
        [Fact]
        public void Pedido_Deve_Calcular_ValorSubtotal_Corretamente()
        {
            var pedido = new Pedido();
            pedido.AdicionarItem(new Cerveja("Heineken", 15));  // taxa 0.2
            pedido.AdicionarItem(new Suco("Prats", 20));  // taxa 0.1
            pedido.AdicionarItem(new Agua("Cristal", 5)); // taxa 0
            pedido.AdicionarItem(new Destilado("Johnnie Walker", 10)); // taxa 0.5

            var total = pedido.CalcularValorSubtotal();

            Assert.Equal(50, total);
        }

        [Fact]
        public void Pedido_Deve_Calcular_ValorTaxas_Corretamente()
        {
            var pedido = new Pedido();
            var data = new DateTime(2026, 1, 1);
            pedido.AdicionarItem(new Cerveja("Heineken", 15));  // taxa 0.2
            pedido.AdicionarItem(new Suco("Prats", 20));  // taxa 0.1
            pedido.AdicionarItem(new Agua("Cristal", 5)); // taxa 0
            pedido.AdicionarItem(new Destilado("Johnnie Walker", 10)); // taxa 0.5

            var total = pedido.CalcularValorTaxas(data);

            Assert.Equal(10, total);
        }

        [Fact]
        public void Pedido_Deve_Calcular_ValorTaxas_EmDezembro_Corretamente()
        {
            var pedido = new Pedido();
            var data = new DateTime(2025, 12, 17);
            pedido.AdicionarItem(new Cerveja("Heineken", 15));  // taxa 0.2
            pedido.AdicionarItem(new Suco("Prats", 20));  // taxa 0.2
            pedido.AdicionarItem(new Agua("Cristal", 5)); // taxa 0
            pedido.AdicionarItem(new Destilado("Johnnie Walker", 10)); // taxa em dezembro 0.1

            var total = pedido.CalcularValorTaxas(data);

            Assert.Equal(6, total);
        }

        [Fact]
        public void Pedido_Deve_Calcular_ValorTotal_Corretamente()
        {
            var pedido = new Pedido();
            var data = new DateTime(2026, 1, 17);
            pedido.AdicionarItem(new Cerveja("Heineken", 15));  // taxa 0.2
            pedido.AdicionarItem(new Suco("Prats", 20));  // taxa 0.1
            pedido.AdicionarItem(new Agua("Cristal", 5)); // taxa 0
            pedido.AdicionarItem(new Destilado("Johnnie Walker", 10)); // taxa 0.5

            var total = pedido.CalcularValorTotal(data);

            Assert.Equal(60, total);
        }
    }
}