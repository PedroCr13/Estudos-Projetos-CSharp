using System;
using System.ComponentModel;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            bool completo = false;
            char genero = 'F';
            char letra = '\u0041';
            byte n1 = 255;
            int n2 = 1000;
            int n3 = 2147483647;
            long n4 = 2147483648L;
            float n5 = 4.5f;
            double n6 = 4.5;
            string nome = "Maria Green";
            object obj1 = "Alex Brown";
            object obj2 = 4.5f;

            Console.WriteLine(obj1);
            Console.WriteLine(obj2);
            Console.WriteLine(nome);
            Console.WriteLine(n5);
            Console.WriteLine(n6);
            Console.WriteLine(letra);
            Console.WriteLine(genero);
            Console.WriteLine(completo);
            Console.WriteLine(n1);
            Console.WriteLine(n2);
            Console.WriteLine(n3);
            Console.WriteLine(n4);

            int nMin = int.MinValue;
            int nMax = int.MaxValue;
            sbyte n11 = sbyte.MinValue;
            decimal n14 = decimal.MaxValue;

            Console.WriteLine(nMin);
            Console.WriteLine(nMax);
            Console.WriteLine(n11);
            Console.WriteLine(n14);
        }
    }
}