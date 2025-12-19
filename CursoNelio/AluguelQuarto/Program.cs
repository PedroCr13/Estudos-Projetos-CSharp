using System;
using System.Net.WebSockets;

namespace Locacao
{
    class Program
    {
        static void Main(string[] args)
        {

            Quarto[] quartos = new Quarto[3];

            System.Console.WriteLine("Quantos quartos serão alugados?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                System.Console.WriteLine("Aluguel #" + i);
                System.Console.Write("Digite o Nome: ");
                string nome = Console.ReadLine();

                System.Console.Write("Digite o Email: ");
                string email = Console.ReadLine();

                bool valida = false;

                while (valida == false)
                {
                    System.Console.Write("Digite o numero do quarto:");
                    int numQuarto = int.Parse(Console.ReadLine());

                    if (numQuarto > quartos.Length - 1)
                    {
                        System.Console.WriteLine("Quarto não cadastrado. Escolha outro.");
                    }
                    else if (quartos[numQuarto] != null)
                    {
                        System.Console.WriteLine("Quarto ocupado. Escolha outro!");
                    }
                    else if (quartos[numQuarto] == null)
                    {
                        quartos[numQuarto] = new Quarto();
                        quartos[numQuarto].estudante.Nome = nome;
                        quartos[numQuarto].estudante.Email = email;
                        System.Console.WriteLine($"Quarto {numQuarto} registrado!");
                        valida = true;
                    }
                }
            }

            for (int i = 0; i < quartos.Length; i++)
            {
                if (quartos[i] != null)
                {
                    System.Console.WriteLine("Quartos ocupados:");
                    System.Console.Write(i + ": " + quartos[i].estudante.Nome + ", "
                                   + quartos[i].estudante.Email);
                }
            }
        }
    }
}