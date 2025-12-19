using System;
using System.Globalization;

namespace Curso
{
    class Program
    { 
        static void Main(string[] args) 
        {
            Console.WriteLine("Digite um valor para calcular desconto com IF: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double desconto;

            if (preco < 20.0) {
                desconto = preco * 0.1;
            }
            else
            {
                desconto = preco * 0.05;
            }

            Console.WriteLine(desconto);

            Console.WriteLine("Digite um valor para calcular desconto com ternário: ");
            preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            desconto = (preco < 20.0) ? preco * 0.1 : preco * 0.05;

            Console.WriteLine(desconto);
        }

    }
}