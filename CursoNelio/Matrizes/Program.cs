using System;

namespace Matrizes
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Digite o tamanho da matriz: ");
            int n = int.Parse(Console.ReadLine());

            int[,] mat = new int[n, n];

            for (int i = 0; i < n; i++) //percorre as linhas
            {
                System.Console.WriteLine("Digite 3 valores: ");
                string[] values = Console.ReadLine().Split(' '); // le a linha inteira e guarda cada valor em um vetor

                for (int j = 0; j < n; j++)
                {
                    mat[i, j] = int.Parse(values[j]);
                }
            }

            System.Console.WriteLine("Main diagonal:");

            for (int i = 0; i < n; i++)
            {
                System.Console.WriteLine(mat[i, i] + " ");
            }
            System.Console.WriteLine("");

            System.Console.WriteLine("numeros negativos: ");

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //linha, coluna
                    if (mat[i, j] < 0)
                    {
                        count++;
                    }
                }
            }

            System.Console.WriteLine("negative numbers: " + count);
        }
    }
}