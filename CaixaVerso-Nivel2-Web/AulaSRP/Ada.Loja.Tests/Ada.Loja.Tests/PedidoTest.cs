using Xunit;

namespace Ada.Loja.Tests
{
   public class PedidoTest
    {
        [Fact]
        public void Pedido_Deve_Calcular_ValorToral_Corretamente()
        {
            var pedido = new Pedido();
            pedido.AdicionarItem(new Item("Cerveja", "heineken", 15));  // taxa 0.2
            pedido.AdicionarItem(new Item("Suco", "Prats", 20));  // taxa 0.1
            pedido.AdicionarItem(new Item("Agua", "Cristal", 5)); // taxa 0

            var total = pedido.CalcularValorTotal();

            Assert.Equal(40, total);
        }

        [Fact]
        public void Pedido_Deve_Calcular_ValorToral_ComTaxasCorretamente()
        {
            var pedido = new Pedido();
            pedido.AdicionarItem(new Item("Cerveja", "Heineken", 15));  // taxa 0.2
            pedido.AdicionarItem(new Item("Suco", "Prats", 20));  // taxa 0.1
            pedido.AdicionarItem(new Item("Agua", "Cristal", 5)); // taxa 0

            var total = pedido.CalcularValorTotalComTaxas();

            Assert.Equal(45, total);
        }
    }
}