using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection.Metadata;

namespace Rh
{
    class Program
    {
        public static void Main(string[] args)
        {
            int id = 0;
            string nome;
            double salario;
            bool valida = false;

            Console.WriteLine("Quantidade de funcionarios?");
            int qtd = int.Parse(Console.ReadLine());

            List<Funcionario> funcionarios = new List<Funcionario>();

            for (int i = 1; i <= qtd; i++)
            {
                valida = false;

                while (!valida)
                {
                    Console.Write("Digite o id: ");
                    id = int.Parse(Console.ReadLine());

                    if (funcionarios.Find(f => f.Id == id) == null)
                    {
                        valida = true;
                    }
                    else
                    {
                        System.Console.WriteLine($"{id} está em uso. Digite outro!");
                    }
                }

                Console.Write("Digite o nome: ");
                nome = Console.ReadLine();

                Console.Write("Digite o salário: ");
                salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                funcionarios.Add(new Funcionario(id, nome, salario));
            }

            foreach (Funcionario f in funcionarios)
            {
                Console.WriteLine(f.ToString());
            }

            Console.Write("Digite o ID para reajuste: ");
            id = int.Parse(Console.ReadLine());

            Funcionario f2 = new Funcionario();
            f2 = funcionarios.Find(f => f.Id == id);

            if (f2 == null)
            {
                System.Console.WriteLine("Id não exise!");
            }
            else
            { 
                System.Console.Write("Didite a porcentagem de aumento: ");
                double aumento = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                f2.AumentarSalario(aumento);
            }

            foreach (Funcionario f in funcionarios)
            {
                Console.WriteLine(f.ToString());
            }
        }

    }
}