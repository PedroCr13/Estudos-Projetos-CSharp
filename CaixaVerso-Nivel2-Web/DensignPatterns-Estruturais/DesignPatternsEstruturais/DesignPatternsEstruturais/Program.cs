using System;
using DesignPatternsEstruturais.Adapter;
using DesignPatternsEstruturais.Bridge;
using DesignPatternsEstruturais.Composite;
using DesignPatternsEstruturais.Decorator;
using DesignPatternsEstruturais.Facade;
using DesignPatternsEstruturais.Flyweight;
using DesignPatternsEstruturais.Proxy;

namespace Aula.DesignPatterns.Estruturais
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            #region Adapter
            Console.WriteLine("\nPadrão Adapter");

            // Padrão de instanciação do C#:
            var ClienteApiExterna = new ClienteApiExterna
            {
                Nome = "Pedro",
                SobreNome = "Lopes",
                DataNascimento = new DateTime(2026, 1, 24),
                Cpf = "000.000.000-00"
            };

            var bancoDeDados = new BancoDeDados();

            var cliente = ClienteApiExterna.ConverterParaCliente();

            bancoDeDados.SalvarCliente(cliente);

            Console.WriteLine("\n[enter] para testar o próximo padrão.");
            Console.ReadKey();

            #endregion Adapter


            #region Bridge
            Console.WriteLine("\nPadrão Bridge:");

            IMessageSender emailSender = new EmailSender();
            IMessageSender smsSender = new SmsSender();

            Message userMessage = new UserMessage(emailSender);
            userMessage.Send("Bem vindo", "Obrigado por se registrar!");

            Message adminMessage = new AdminMessage(smsSender);
            adminMessage.Send("Alerta", "ação necessária");

            Console.WriteLine("\n[enter] para testar o próximo padrão.");
            Console.ReadKey();
            #endregion Brigde


            #region Composite
            Console.WriteLine("\nPadrão composite:");

            // um departamento pode ter outros departamentos ou empregados

            var devTeam = new Department("Development Team");
            devTeam.Add(new Employee("Alice", 8000));
            devTeam.Add(new Employee("Bob", 9000));

            var qaTeam = new Department("QA Team");
            qaTeam.Add(new Employee("Charlie", 7000));

            var techDepartment = new Department("Tech Department");
            techDepartment.Add(devTeam);
            techDepartment.Add(qaTeam);
            techDepartment.Add(new Employee("Dave", 12000));

            Console.WriteLine($"Total salary for {techDepartment.GetName()}: ${techDepartment.CalculateTotalSalary()}");

            Console.WriteLine("\n[enter] para testar o próximo padrão.");
            Console.ReadKey();
            #endregion Composite


            #region Decorator
            Console.WriteLine("\nPadrão Decorator:");

            Bebida bebida = new Cafe();
            Console.WriteLine($"{bebida.Descricao}: R$ {bebida.Custo()}");

            bebida = new Leite(bebida);
            Console.WriteLine($"{bebida.Descricao}: R$ {bebida.Custo()}");

            bebida = new Chantily(bebida);
            Console.WriteLine($"{bebida.Descricao}: R$ {bebida.Custo()}");

            Console.WriteLine("\n[enter] para testar o próximo padrão.");
            Console.ReadKey();
            #endregion Decorator


            #region Facade
            Console.WriteLine("\nPadrão Facade:");

            BibliotecaFacade biblioteca = new BibliotecaFacade();
            biblioteca.EmprestarLivro("Joao", "1984");

            Console.WriteLine("\n[enter] para testar o próximo padrão.");
            Console.ReadKey();
            #endregion Facade

            #region Flyweight
            Console.WriteLine("\nPadrão Flyweight:");

            Documento doc = new Documento();

            doc.AdicionarCaractere('A', "Arial", 12, ConsoleColor.Red, 1);
            doc.AdicionarCaractere('B', "Arial", 12, ConsoleColor.Red, 2);
            doc.AdicionarCaractere('A', "Arial", 12, ConsoleColor.Red, 3); // reutizando mesmo objeto

            Console.WriteLine("\n[enter] para testar o próximo padrão.");
            Console.ReadKey();
            #endregion Flyweight


            #region Proxy
            Console.WriteLine("\nPadrão Proxy:");

            ProxyDocumento proxy = new ProxyDocumento("conteúdo sensível", new PermissaoUsuario());
            proxy.MostrarDocumento("admin");
            proxy.MostrarDocumento("guest");

            Console.ReadKey();
            #endregion Proxy
        }
    }
}