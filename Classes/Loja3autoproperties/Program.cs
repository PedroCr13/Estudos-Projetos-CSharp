using System;
using System.Globalization;
using static System.Console;

namespace Course
{
    class Program
    {
        static void Main(String[] args)
        {
            Produto p = new Produto("TV", 300.00);
            p.Nome = "TV 4K";

            WriteLine(p.Nome);
            WriteLine(p.Preco);
            WriteLine(p.Quantidade);

            /*
            WriteLine("Entre os dados do produto");
            Write("Nome: ");
            string nome  = Console.ReadLine();

            WriteLine("Preco: ");
            double preco  = double.Parse(ReadLine(), CultureInfo.InvariantCulture);

            Produto p = new Produto(nome, preco);

            Produto p3 = new Produto
            {
                Nome = "Tv",
                Preco = 500.00,
                Quantidade = 20
            };

            WriteLine("Estoque atual: " + p);

            WriteLine("Dados do produto");
            WriteLine("Digite qtd de produtos a ser adicionado: ");
            int qte = int.Parse(ReadLine());

            p.AdicionarProdutos(qte);

            WriteLine("Dados atualizados após a inserção: " + p);

            WriteLine("Dados do produto");
            WriteLine("Digite qtd de produtos a ser Removida: ");
            qte = int.Parse(ReadLine());

            p.RemoverProdutos(qte);

            WriteLine("Dados atualizados após a remoção: " + p);
            */
        }
    }
}