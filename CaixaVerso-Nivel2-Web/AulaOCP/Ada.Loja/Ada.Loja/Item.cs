using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Loja
{
    public abstract class Item
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

        public abstract decimal ObterTaxa();
    }
}

// classe abstrata passa a ser classe base para outras classes
// não pode ser instanciada, quem herdar deve implementar os metodos

// calculo de taxa passou a ser responsabilidade de cada classe de produto
// Este trecho é como era antes centralizado em apenas um metodo
// precisava ser alterada esta classe Item sempre que havia necessidade de um novo produto
// public decimal ObterTaxa()
// { 
//    if (this.Categoria == "Cerveja")
//    {
//        return 0.2M;
//    }
//    else if (this.Categoria == "Suco")
//    {
//        return 0.1M;
//    }
//    else if (this.Categoria == "Destilado")
//    {
//        return 0.5M;
//    }
//    else
//    {
//        return 0;
//    }
// }


