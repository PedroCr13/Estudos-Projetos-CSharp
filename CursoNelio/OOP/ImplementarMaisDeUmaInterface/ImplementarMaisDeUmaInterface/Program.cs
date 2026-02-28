using ImplementarMaisDeUmaInterface.Devices;
using System;

namespace Curso
{
    class Program
    {
        public static void Main(string[] args)
        {
            ComboDevice c = new ComboDevice() { SerialNumber = 3921 };
            c.ProcessDoc("My dissertation");
            c.Print("My dissertation");
            Console.WriteLine(c.Scan());
        }
    }
}