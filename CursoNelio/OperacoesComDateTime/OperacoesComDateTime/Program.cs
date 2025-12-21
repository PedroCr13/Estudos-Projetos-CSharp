using System;

namespace Course
{
    public class Program
    {
        static void Main(string[] args)
        {
            DateTime d = new DateTime(2001, 8, 15, 13, 45, 58);

            DateTime d2 = d.AddHours(2);
            DateTime d3 = d.AddMinutes(3);

            DateTime d4 = d.AddDays(30);

            Console.WriteLine(d);
            Console.WriteLine(d2);
            Console.WriteLine(d3);
            Console.WriteLine(d4);

            // Diferença entre datas:
            DateTime dataAdmissao = new DateTime(2025, 07, 16);
            DateTime dataAtual = new DateTime(2025, 12, 22);

            TimeSpan t = dataAtual.Subtract(dataAdmissao);

            Console.WriteLine(t);
        }
    }
}