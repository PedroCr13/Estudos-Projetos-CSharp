using Ada.DesignPatterns.Builder;
using DensignPatterns.Criacionais.AbstractFactory;
using DensignPatterns.Criacionais.Factory;
using DensignPatterns.Criacionais.Prototype;
using DensignPatterns.Criacionais.Singleton;
using System;

/*
   Anotações aula: quais serão abordados:
  
   Design Patterns: Soluções padronizadas para problemas comuns recorrentes em projetos de SW.
   Soluções testadas e documentadas.

   Com estes padrões não há necessidade de "reiventar a roda".
   Melhor comunicação entre DEVs (fluidez, todos falam a mesma língua)
   Quando muda para outro projeto ou outra empresa quando seguiu padrões facilita entendimento do projeto
   Soluções robustas.
    
   Livro Design Patterns > há 23 padrões.
    
   Padrões se dividem em: 
   Criacionais: ajudam na criação de objetos
   Estruturais: como objetos e classes são compostos para formar estruturas maiores
   Comportamentais: Comunicação entre objetos, definir como objetos interagem e distribuem responsabilidades.

   Criacionais: Singleton / Factory Abstract Factory / Builder / Prototype
   Estruturais: Adapter / Decorator / Facade
   Comportamentais: Oberserver / Strategy / Command

   Manter equilibrio! cuidar com a Paternite => querer usar design patterns em tudo causando excesso de engenharia "Over-engineering"
*/
namespace Ada.DesignPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Singleton
            MeuBancoDeDados banco1 = MeuBancoDeDados.ObterInstancia();
            MeuBancoDeDados banco2 = MeuBancoDeDados.ObterInstancia();

            Console.WriteLine("Demonstração do Singleton: ");

            if (banco1 == banco2)
            {
                Console.WriteLine("Teste Singleton: As instâncias são as mesmas!");
            }
            else
            {
                Console.WriteLine("Teste Singleton:  As instâncias são diferentes!");
            }
            // Em API.net: pode se fazer injeção de dependência: service.AddSingleton<MeuBancoDeDados>() para aplicação toda

            Console.WriteLine("\nEnter para ver o próximo padrão..");
            Console.ReadKey();
            #endregion Singleton
            


            #region Factory
            // para o programa principal é inferente com qual tipo de log está trabalhando
            CriadorDeLog logCreator;

            Console.WriteLine("\nDemonstração do Factory: ");
            Console.WriteLine("Digite simples para log simples ou outra coisa para log detalhado: ");
            string input = Console.ReadLine();

            // subclasse que será instanciada:
            if (input.ToLower() == "simples")
            {
                logCreator = new CriadorLogSimples();
            }
            else
            {
                logCreator = new CriadorLogDetalhado();
            }

            logCreator.LogMessage("Teste de log!");

            Console.WriteLine("\nEnter para ver o próximo padrão..");
            Console.ReadKey();
            #endregion Factory



            #region AbsractFactory
            IFabricaInterfaceGrafica fabrica;
            Aplicacao aplicacao;

            Console.WriteLine("\nDemonstração do Singleton: ");
            Console.WriteLine("Digite claro para tema Claro ou escuro para o tema Escuro");
            string tema = Console.ReadLine().ToLower();

            if (tema == "claro")
            {
                fabrica = new FabricaTemaClaro();
            }
            else
            {
                fabrica = new FabricaTemaEscuro();
            }

            aplicacao = new Aplicacao(fabrica);
            aplicacao.Desenhar();

            Console.WriteLine("\nEnter para ver o próximo padrão..");
            Console.ReadKey();
            #endregion AbsractFactory



            #region Builder
            Console.WriteLine("Padrão Builder");

            DiretorInterface diretor = new DiretorInterface();
            InterfaceBuilder builder;

            Console.WriteLine("Digite o tipo de cliente: (padrao, vip ou consultor)");
            string tipoCliente = Console.ReadLine().ToLower();

            switch (tipoCliente)
            {
                case "vip":
                    builder = new ClienteVipBuilder();
                    break;

                case "consultor":
                    builder = new ClienteConsultorBuilder();
                    break;

                default:
                    builder = new ClientePadraoBuilder();
                    break;
            }

            var interfaceUsuario = diretor.MostarInterface(builder);
            interfaceUsuario.MostrarInterface();
            Console.ReadKey();

            #endregion Builder



            #region Prototype
            Console.WriteLine("Padrão Prototype");

            Documento docOriginal = new Documento("Documento Original", "Este é conteúdo do doc. original.");

            Documento docCopia = docOriginal.Clone() as Documento;

            docCopia.Conteudo = "Este conteúdo foi modificado na cópia";

            Console.WriteLine("\nDocumento original: ");
            docOriginal.Print();

            Console.WriteLine("\nDocumento Cópia: ");
            docCopia.Print();

            Console.ReadKey();
            #endregion Prototype
        }
    }
}