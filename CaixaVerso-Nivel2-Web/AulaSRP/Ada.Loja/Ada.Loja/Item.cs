using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Loja
{
    public class Item
    {
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public Item(string categoria, string descricao, decimal valor)
        {
            Categoria = categoria;
            Descricao = descricao;
            Valor = valor;
        }

        public decimal ObterTaxa()
        {
            if (this.Categoria == "Cerveja")
            {
               return 0.2M;
            }
            else if (this.Categoria == "Suco")
            {
                return 0.1M;
            }
            else
            {
               return 0;
            }
        }
    }
}
