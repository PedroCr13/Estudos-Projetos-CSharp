using System;
using System.Globalization;

namespace Vetores
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Tamanho do vetor: ");
            int n = int.Parse(Console.ReadLine());

            //instancia apenas o vetor (não os objetos nas posições)
            Produto[] produtos = new Produto[n];

            for (int i = 0; i < n; i++)
            {
                System.Console.Write("Nome Produto: ");
                string nome = Console.ReadLine();
                System.Console.Write("Preço Produto: ");
                double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                //instanciando o objeto da posição
                produtos[i] = new Produto();
                produtos[i].Nome = nome;
                produtos[i].Preco = preco;
            }

            double soma = 0.0;

            for (int i = 0; i < n; i++)
            {
                soma += produtos[i].Preco;
            }

            double avg = soma / n;

            System.Console.WriteLine("Preco medio = " + avg.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}