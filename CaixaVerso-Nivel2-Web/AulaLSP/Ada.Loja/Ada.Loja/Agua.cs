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


    }
}

/*
 *  Conceito de Liskov LSP
    Se temos uma classe derivada Água, Cerveja, Suco, Destilado que herda de Item
    qualquer uma destas classes DEVE substituir Item sem causar erro
*/

// água não tem taxa, esta forma está incorreta.
// Se não retornar valor causará erro no programa.
// fere LSP
//public override decimal ObterTaxa()
//{
//    // Propositalmente sem retorno para quebrar.
//    // Será utilizado uso de interface na próxima aula.
//    throw NotImplementException();
//}