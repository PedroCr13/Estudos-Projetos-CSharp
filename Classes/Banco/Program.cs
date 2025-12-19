using System;
using System.Globalization;
using static System.Console;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Entre nº da conta:");
            int numeroConta = int.Parse(ReadLine());

            WriteLine("Entre o titular: ");
            string titular = ReadLine();

            WriteLine("Havera depósito inicial? s/n");
            char resposta = char.Parse(ReadLine());

            Conta c1;
            double valor;

            if (resposta == 's' || resposta == 'S')
            {
                WriteLine("Valor do Depósito Inicial: ");
                valor = double.Parse(ReadLine(), CultureInfo.InvariantCulture);

                c1 = new Conta(numeroConta, titular, valor);
            }
            else
            {
                c1 = new Conta(numeroConta, titular);
            }

            WriteLine(c1);

            WriteLine("Valor do depósito: ");
            valor = double.Parse(ReadLine(), CultureInfo.InvariantCulture);
            c1.Depositar(valor);

            WriteLine(c1);

            WriteLine("Valor do saque: ");
            valor = double.Parse(ReadLine(), CultureInfo.InvariantCulture);
            c1.Sacar(valor);

            WriteLine(c1);
        }
    }
}
