using System;

namespace Matrizes
{
    class Exemplo
    {
        //arranjo bidimensional: linhas e colunas
        public void exemploMatrizes() { 
            double[,] mat = new Double[2, 3];

            System.Console.WriteLine(mat.Length); //quantidade de elementos
            System.Console.WriteLine(mat.Rank); // primeira dimensão (qtd linhas)
            System.Console.WriteLine(mat.GetLength(0)); //qtd de linhas 1 dimensão
            System.Console.WriteLine(mat.GetLength(1)); //qtd de colunas 2 dimensão
        }
    }
}