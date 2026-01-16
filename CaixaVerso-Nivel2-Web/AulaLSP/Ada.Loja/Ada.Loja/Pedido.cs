using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Loja
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public List<Item> itens { get; set; }

        public Pedido()
        { 
            Id = Guid.NewGuid();
            itens = new List<Item>();
        }

        public void AdicionarItem(Item item) 
        {
            itens.Add(item);
        }

        public decimal CalcularValorSubtotal()
        {
            decimal total = 0;
            foreach (var item in itens) 
            {
                total += item.Valor;
            }

            return total;
        }

        public decimal CalcularValorTaxas()
        {
            decimal taxas = 0;
            foreach (var item in itens)
            {
                taxas += item.ObterValorTotal(); 
            }

            return taxas;
        }

        public decimal CalcularValorTotal()
        {
            return this.CalcularValorSubtotal() + CalcularValorTaxas();
        }
    }
}
