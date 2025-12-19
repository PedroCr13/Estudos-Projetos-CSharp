using System;
using System.Collections.Generic; //Listas

namespace Listas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>(); //instancia list vazia

            List<string> list2 = new List<string> { "Pedro", "Alex" };

            List<string> lista = new List<string>();

            lista.Add("Pedro"); //add adiciona ao final da lista
            lista.Add("Maria");
            lista.Add("Alex");
            lista.Add("Ana");
            lista.Insert(4, "Marco");

            foreach (string obj in lista)
            {
                System.Console.WriteLine(obj);
            }

            System.Console.WriteLine("Tamanho da lista: " + lista.Count);

            string s1 = lista.Find(Test); // recebe como argumento uma função que faz o teste.

            Console.WriteLine("First A: " + s1);

            string s2 = lista.Find(x => x[0] == 'A'); // recebe como argumento um expressão lambda
                                                      //(x => x[0] == A) quero do elmento X, tal que X na primeira posição seja igual a A
                                                      // dado o string X, pega o primento elemento se for A

            Console.WriteLine("First A: " + s2);

            string s3 = lista.FindLast(x => x[0] == 'A'); //encontrar o ultimo elemento da lista que satisfaça um predicado
            Console.WriteLine(s3);

            int pos1 = lista.FindIndex(x => x[0] == 'A'); //busca primeira posicao (no caso primeira ocorrencia de 1 letra A na string)
            Console.WriteLine("primeira posicao em que na string A é primeira letra: " + pos1);

            int pos2 = lista.FindLastIndex(x => x[0] == 'A');
            Console.WriteLine("ultima posicao com primeira letra de A: " + pos2);

            //Filtrar lista com base em um predicado. Criar uma nova lista apenas com elementos que satisfaçam predicado:
            List<string> listResultadoFiltro = lista.FindAll(x => x.Length == 5);

            foreach (string item in listResultadoFiltro)
            {
                System.Console.WriteLine(item);
            }

            //Remover elementos da lista

            lista.Remove("Alex");

            foreach (string item in lista)
            {
                System.Console.WriteLine(item);
            }

            System.Console.WriteLine("RemoveAll:");

            lista.RemoveAll(x => x[0] == 'M');

            foreach (string item in lista)
            {
                System.Console.WriteLine(item);
            }

            System.Console.WriteLine("remover na posicao");

            lista.RemoveAt(0);
            foreach (string item in lista)
            {
                System.Console.WriteLine(item);
            }

            //RemoveRange remover elementos de uma faixa:

            lista.RemoveRange(2, 2); //passa a posicao inicial e a ultima

        }
        
        static bool Test(string s)
        {
            return s[0] == 'A';
        }
    }
}