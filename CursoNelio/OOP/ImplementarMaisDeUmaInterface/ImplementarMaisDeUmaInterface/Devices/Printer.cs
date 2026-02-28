using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementarMaisDeUmaInterface.Devices
{
    class Printer : Device, IPrinter
    {
        // do device
        public override void ProcessDoc(string document)
        {
            Console.WriteLine("Printer processing: " + document);
        }

        // do IPrinter
        public void Print(string document) 
        { 
            Console.WriteLine("Printer print " + document);
        }
    }
}
