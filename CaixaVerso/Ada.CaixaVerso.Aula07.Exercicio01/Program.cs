using System.Diagnostics;

namespace Ada.CaixaVerso.Polimorfismo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Sistema de Controle de Pedidos:");

            ProcessadorDePedidos pedidoPadrao = new ProcessadorDePedidos();
            pedidoPadrao.ValorCompra = 1000.00;

            Console.WriteLine("Pedido com desconto de 5% (padrão):");
            Console.WriteLine($"Valor final do pedido: {pedidoPadrao.Processar(10)}");
            Console.WriteLine($"Id do Pedido: {pedidoPadrao.IdPedido}");
            Console.WriteLine($"Cliente: {pedidoPadrao.NomeCliente}");
            Console.WriteLine($"Valor da Compra: {pedidoPadrao.ValorCompra}");
            Console.WriteLine("");

            ProcessadorDePedidos pedidoVip = new ProcessadorDePedidos();
            pedidoVip.ValorCompra = 2000.00;

            Console.WriteLine("Pedido com desconto de 10% (VIP):");
            Console.WriteLine($"Valor final do pedido: {pedidoVip.Processar(1, "Joao Silva")}");
            Console.WriteLine($"Id do Pedido: {pedidoVip.IdPedido}");
            Console.WriteLine($"Cliente: {pedidoVip.NomeCliente}");
            Console.WriteLine($"Valor da Compra: {pedidoVip.ValorCompra}");
            Console.WriteLine("");

            ProcessadorDePedidos pedidoDevolvido = new ProcessadorDePedidos();
            
            Console.WriteLine("Devolução de Pedido (Retenção de 50%):");
            Console.WriteLine($"Valor final do pedido: {pedidoDevolvido.Processar(1000.00, "TV")}");
            Console.WriteLine($"Cliente: {pedidoDevolvido.NomeCliente}");
            Console.WriteLine($"Valor da Compra: {pedidoDevolvido.ValorCompra}");
            Console.WriteLine($"Produto devolvido: {pedidoDevolvido.ItemDevolvido}");
        } 
    }
}