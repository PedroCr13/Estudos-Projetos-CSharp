using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDDemo
{
    public class GiraLista
    {
        public List<int> Girar(List<int> lista)
        {
            // 1ª código que passou no teste (ainda não ideal)
            // return new List<int> { 15, 20, 30, 10 };

            // refatoração:
            //var item1 = lista[1];
            //return new List<int> { item1, 0, 0, 0 };

            // Ultima versão refatoração:
            var item0 = lista[0];
            var nova = new List<int>();
            lista.RemoveAt(0);
            nova.AddRange(lista);
            nova.Add(item0);
            return nova;
        }
    }
}
