using System;

namespace Course
{
    class Program
    {
        static void Main(string[] args) {

            var x = 10;
            var y = 20.0;
            var z = "Maria";

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);

            // Cuidado ao usar var, aceita qualquer tipo de dados, 
            // explicitando o tipo a IDE avisa caso tenha atribuido um tipo por engano
            var w = z; 



        }
    }
}