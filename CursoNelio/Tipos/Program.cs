using System;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p;
            p.X = 10;
            p.Y = 20;
            System.Console.WriteLine(p);

            p = new Point(); //reinia valores

            System.Console.WriteLine(p);
        }
    }
}