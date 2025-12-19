namespace Ada.CaixaVerso.Polimorfismo
{
    public class ProcessadorDePedidos
    {
        public int IdPedido { get; private set; }
        public string NomeCliente { get; private set; }
        public double ValorCompra { get; set; }
        public double ValorFinalPedido { get; private set; }
        public string ItemDevolvido { get; private set; }

        public double Processar(int idPedido)
        {
            IdPedido = idPedido;
            NomeCliente = "Consumidor";
            ValorFinalPedido = ValorCompra * 0.95;
            return ValorFinalPedido;
        }

        public double Processar(int idPedido, string nomeCliente)
        {
            IdPedido = idPedido;
            NomeCliente = nomeCliente;
            ValorFinalPedido = ValorCompra * 0.90;
            return ValorFinalPedido; 
        }

        public double Processar(double valor, string nomeDoitem)
        {
            IdPedido = 0;
            NomeCliente = "Devolução";
            ItemDevolvido = nomeDoitem;    
            ValorCompra = valor;
            ValorFinalPedido = ValorCompra * 0.50;
            return ValorFinalPedido;
        }
    }
}