using System;

namespace Curso
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            string day; // 1 domingo, 2 segunda, etc

            switch (x) {
                case 1:
                    day = "Sunday";
                    break;

                case 2:
                    day = "Monday";
                    break;

                case 3:
                    day = "Tuesday";
                    break;

                case 4:
                    day = "Wednesday";
                    break;

                case 5:
                    day = "Thursday";
                    break;

                case 6:
                    day = "Friday";
                    break;

                case 7:
                    day = "Saturday";
                    break;

                default: // testou todas e nenhum se equadrou nas anteriores:
                    day = "Invalid value";
                    break;

            }

            Console.WriteLine(day);
        }
    }
}
