using System;

namespace ImplementarMaisDeUmaInterface.Devices
{
    // herda de Device e implementa interfaces IScanner e IPrinter
    class ComboDevice : Device, IScanner, IPrinter
    {
        public void Print(string document)
        {
            Console.WriteLine("ComboDevice print: " + document);    
        }

        public override void ProcessDoc(string document)
        {
            Console.WriteLine("ComboDevice processing: " + document);
        }

        public string Scan()
        {
            return "ComboDevice scan result";
        }
    }
}
