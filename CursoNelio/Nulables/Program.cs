using System;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nullable<double> x = null; //outra forma
            double? x = null; //opcional
            double? y = 10.0;
            System.Console.WriteLine(x.GetValueOrDefault()); //se X estiver sem valor, pega valor padrão 0
            System.Console.WriteLine(y.GetValueOrDefault());

            System.Console.WriteLine(x.HasValue); //existe valor ou não?
            System.Console.WriteLine(y.HasValue);

            if (x.HasValue)
                System.Console.WriteLine(x.Value); //lança exceção se objeto nullable estiver nulo
            else
                System.Console.WriteLine("X é nulo");

            if (y.HasValue)
                System.Console.WriteLine(y.Value);
            else
                System.Console.WriteLine("y é nulo");


            double? b = null; //? pode aceitar null.
            double? c = 10;
                                //?? operado de coalecência nula
            double a = b ?? 5; //joga 5 no a se b nulo, sem b tem valor joga o valor de b
            double d = c ?? 5; //joga 5 no d se c for nulo, se c tem valor joga o valor de c

            System.Console.WriteLine(a);
            System.Console.WriteLine(d);   
        }
    }
}