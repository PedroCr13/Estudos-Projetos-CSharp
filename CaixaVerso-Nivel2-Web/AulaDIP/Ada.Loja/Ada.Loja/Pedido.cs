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

        public decimal CalcularValorTaxas(DateTime data)
        {
            decimal taxas = 0;
            foreach (var item in itens)
            {
                var itemComTaxa = item as ItemComTaxa;

                if (itemComTaxa != null) 
                {
                    taxas += itemComTaxa.ObterValorTotalTaxa(data);
                }
            }

            return taxas;
        }

        public decimal CalcularValorTotal(DateTime data)
        {
            return this.CalcularValorSubtotal() + CalcularValorTaxas(data);
        }
    }
}
