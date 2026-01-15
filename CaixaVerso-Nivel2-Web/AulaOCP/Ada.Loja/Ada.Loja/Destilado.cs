using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Loja
{
    public class Destilado : Item
    {
        public Destilado(string descricao, decimal valor) : base("Destilado", descricao, valor)
        {
        }

        public override decimal ObterTaxa()
        {
            return 0.5M;
        }
    }
}
