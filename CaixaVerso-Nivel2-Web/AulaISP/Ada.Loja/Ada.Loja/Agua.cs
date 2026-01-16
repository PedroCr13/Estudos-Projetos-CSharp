using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Loja
{
    public class Agua : Item
    {
        public Agua(string descricao, decimal valor) : base("Agua", descricao, valor)
        {
        }

        // água não tem taxa, esta forma está incorreta, pois estaria implementando um metodo desnecessario
        // Se não retornar valor causará erro no programa.
        // fere LSP
        // criada classe abstrata ItemComTaxa herdando de Item (sem taxa)
        // public override decimal ObterTaxa()
        // {
            // Propositalmente sem retorno para quebrar.
            // Será utilizado uso de interface na próxima aula.
        // }
    }
}

/*
 *  Conceito de Liskov LSP
    Se temos uma classe derivada Água, Cerveja, Suco, Destilado que herda de Item
    qualquer uma destas classes DEVE substituir Item sem causar erro
*/