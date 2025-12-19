using System;

namespace Laco
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vect = new string[] { "Maria", "Bob", "Alex" };

            // para cada obj contido no vetor vect faça
            foreach (string obj in vect)
            {
                System.Console.WriteLine(obj);
            }
        }
    }
}