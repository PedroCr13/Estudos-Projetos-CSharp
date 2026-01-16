using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * não possui mais um Item com o metódo para calcular taxa 
 * as clases que herdarem de Item com taxa terão apenas os metodos necessários    
 * consegue substituir as classes sem causar erros (sem violação do principio de Liskov)
 * ISP: reduz acomplamento e aumenta coesão
 * desafio: encontrar equilibrio nem sempre será ncessário em sistemas menores, quebrar demais em classes pode acabar mais prejudicando do que ajudando
 */

namespace Ada.Loja
{
    public abstract class ItemComTaxa : Item
    {
        public ItemComTaxa(string categoria, string descricao, decimal valor) : base(categoria, descricao, valor)
        {
        }
        public abstract decimal ObterTaxa();

        public decimal ObterValorTotalTaxa()
        {
            return this.ObterTaxa() * this.Valor;
        }
    }
}
