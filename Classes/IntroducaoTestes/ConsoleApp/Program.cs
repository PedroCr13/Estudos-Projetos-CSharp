using System;
using IntroducaoTestes.LibraryApp.ExtensionMethods;

/*
    teste sendo realizado na própria aplicação, a boa prática é criar um projeto de testes 
    com mesmo nome do projeto principal acrescido do sufixo Test

    Foi Criada uma classe de Extension Method para a classe String que será usada nos exercicios
*/

namespace IntroducaoTestes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           var vazio = "Olá mundo do teste unitário!".Remover();

           if (string.IsNullOrEmpty(vazio))
            {
                Console.WriteLine("remover: OK");
            }
            else
            {
                Console.WriteLine($"Remover falhou: era para receber '', mas recebeu [vazio]");
            }
            Console.ReadKey();
        }
    }
}