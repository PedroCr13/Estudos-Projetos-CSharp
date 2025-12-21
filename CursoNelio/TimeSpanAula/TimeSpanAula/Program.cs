using System;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan t1 = new TimeSpan(0, 1, 30);
            Console.WriteLine(t1);
            Console.WriteLine(t1.Ticks);

            TimeSpan t2 = new TimeSpan(); // Duração padrão = 0
            Console.WriteLine(t2);

            TimeSpan t3 = new TimeSpan(900000000L);
            Console.WriteLine(t3);

            TimeSpan t4 = new TimeSpan(2, 11, 21); // 2h 11m 21s
            Console.WriteLine(t4);

            TimeSpan t5 = new TimeSpan(1, 2, 11, 21); // dias, horas, minutos, segundos
            Console.WriteLine(t5);

            TimeSpan t6 = new TimeSpan(1, 2, 11, 21, 321);
            Console.WriteLine(t6);

            TimeSpan t7 = TimeSpan.FromDays(1.5); // equivalente a 1,5 dia
            Console.WriteLine(t7);

            TimeSpan t8 = TimeSpan.FromHours(1.5);
            Console.WriteLine(t8);
        }
    }
}