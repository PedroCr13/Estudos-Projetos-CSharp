using System;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace Calculatora
{
    class Program
    {
        static void Main(String[] args)
        {
            int s1 = Calculatora.Sum(2, 3);

            System.Console.WriteLine(s1);

            //int s2 = Calculatora.Sum(new int[] { 10, 20, 30, 40 });

            //chama função com parametros variáveis
            int s2 = Calculatora.Sum(100, 200, 300, 400, 500);

            System.Console.WriteLine(s2);

            //testa modificador de paramentro ref
            //ref exige que a variável serja inicilizada. 
            int a = 10; //iniciando variavel que ser passada como parametro ref.
            Calculatora.Triple(ref a);
            System.Console.WriteLine(a);

            //Out
            int b = 10;
            int triple;
            Calculatora.TripleComOut(b, out triple);
            System.Console.WriteLine(triple);
        }
    }
}