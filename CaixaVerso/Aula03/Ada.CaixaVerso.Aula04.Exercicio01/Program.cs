/*
    Criar um sistema de cadastro de produtos, que receba, nome do produto, quantidade e preço. 
    E que tenha ação de aumentar estoque. 
    Use o conceito da aula, para criar, usando objetos, classes e listas
*/
using System.Globalization;

namespace Ada.CaixaVerso.Aula04.Exercicio
{
    public class Program
    {   
        public static Produto CaadastrarProduto()
        {
            Produto produto = new Produto();
            string nome;
            int id;
            int quantidade;
            double preco;

            Console.WriteLine("Qual o Id do produto:");
            id = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do prduto: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite a quantidade inicial do produto: ");
            quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o preço do produto: ");
            preco = double.Parse(Console.ReadLine(), new CultureInfo("pt-BR"));

            produto.Id = id;
            produto.Nome = nome;
            produto.Quantidade = quantidade;
            produto.Preco = preco;

            return produto;
        } 

        public static void AumentarEstoque(List<Produto> produtos)
        {
            Console.WriteLine("Qual produto deseja aumentar estoque? ");
            string resposta = Console.ReadLine();

            foreach (Produto p in produtos)
            {
                if (p.Nome.Equals(resposta))
                {
                    Console.WriteLine("Quer aumentar quanto?");
                    int qtdAdicionar = int.Parse(Console.ReadLine());
                    p.AumentarEstoque(qtdAdicionar);
                }        
            }
        }

        public static void desenhaCabecalho()
        {
            Console.WriteLine(" ** ********* ***********");
            Console.WriteLine(" ** Sistema de Estoque **");
            Console.WriteLine(" ***** *************** **");
        }

        public static int MostraMenuInicial()
        {       
            bool conitnuar = true;
            int opcaoSelecionada = 0;

            while (conitnuar)
            {
                Console.Clear();
                desenhaCabecalho();
                Console.WriteLine(" 1 - Cadastrar Produtos");
                Console.WriteLine(" 2 - Aumentar Quantidade do Produto");
                Console.WriteLine(" 3 - Exibir produtos em Estoque");
                Console.WriteLine(" 4 - Sair do sistema.");

                Console.WriteLine("\nDigite uma opção de 1 a 4: ");
                opcaoSelecionada = int.Parse(Console.ReadLine());

                if ((opcaoSelecionada < 1) || (opcaoSelecionada > 4))
                {
                    Console.WriteLine("Opcao inválida. Deve ser de 1 a 4! Digite novamente!");
                    Console.Clear();
                } else
                {
                    conitnuar = false;
                }
            }

            return opcaoSelecionada;
        }
        static void Main(string[] args)
        {
            Banco estoque = new Banco();
            int opcao = 0;
            bool conitnuar = true;

            while (conitnuar){
                opcao = MostraMenuInicial();

                if (opcao == 1)
                {
                    Console.Clear();

                    Console.WriteLine(" *** Cadastro de Produto *** ");

                    Console.WriteLine("\nQuantos produtos deseja cadastrar no estoque?");
                    int quantidadeDeCadastros = int.Parse(Console.ReadLine());

                    for (int i = 0; i < quantidadeDeCadastros; i++)
                    {
                        Console.Clear();
                        Console.WriteLine($"Cadastrando {i + 1} de {quantidadeDeCadastros}");
                        Produto p = CaadastrarProduto();
                        estoque.AdicionarProduto(p);
                    }

                    MostraMenuInicial();

                    Console.WriteLine("\nPressione enter para retornar ao menu...");
                    Console.ReadKey();
                } 
                else if (opcao == 2)
                {
                    Console.Clear();
                    Console.WriteLine(" ** Produtos em estoque:  **");
                    estoque.ListarEstoque();

                    Console.WriteLine("\nQual o Id do produto que deseja aumentar quantidade?");
                    int idProduto = int.Parse(Console.ReadLine());

                    Console.WriteLine("Qual a quantidade deseja acrescentar?");
                    int qtdAcrescimo = int.Parse(Console.ReadLine());

                    estoque.AumentarQuantidadeProduto(idProduto, qtdAcrescimo);
                    
                    Console.WriteLine("\nPressione enter para retornar ao menu...");
                    Console.ReadKey();

                    MostraMenuInicial();
                } 
                else if (opcao == 3)
                {
                    Console.Clear();
                    Console.WriteLine(" ** Listando Produtos em Estoque **");
                    estoque.ListarEstoque();

                    Console.WriteLine("\nPressione enter para retornar ao menu...");
                    Console.ReadKey();

                    MostraMenuInicial();
                } 
                else if (opcao == 4)
                {
                    Console.Clear();
                    conitnuar = false;
                }
            }
        }
    }
}