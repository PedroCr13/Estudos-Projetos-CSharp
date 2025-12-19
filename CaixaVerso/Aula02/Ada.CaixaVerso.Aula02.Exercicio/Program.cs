/*
    Você foi contratado para criar um pequeno sistema de análise de vendas para uma loja de eletrônicos. 
    
    O sistema deve armazenar os nomes de 4 produtos
    e registrar as vendas de cada um desses produtos ao longo de 3 meses (um trimestre).

    1. Criar o Vetor de Produtos (Array Unidimensional)
    Crie um vetor de strings chamado nomesProdutos e inicialize-o com os nomes dos mesmos.

    2. Criar a Matriz de Vendas (Array Bidimensional)
    Crie uma matriz de inteiros (int) chamada vendasTrimestrais de dimensão 4x3 (4 linhas para os produtos e 3 colunas para os meses).

    Linhas: Representam os produtos, na mesma ordem do vetor nomesProdutos.

    Colunas: Representam os meses (Mês 1, Mês 2, Mês 3).

    Preencha manualmente a matriz vendasTrimestrais.

    Produto    |  Mês 1 | Mês 2 | Mês 3
    SmartTV  |  150      | 180     |  280

    //int[,] matriz = new int[3, 3];
    //string[,] matrizString = new string[3, 3];
*/

Console.WriteLine("Sistema de Vendas");

string[] vetorDeProdutos = new string[4];
int[,] vendasTrimestrais = new int[4, 3];
string nomeDoProduto;
int qtdVendas;

Console.WriteLine("Cadastro de produtos:");

for (int i = 0; i < 4; i++)
{
    Console.WriteLine($"Digite o nome do produto {i + 1}:");
    nomeDoProduto = Console.ReadLine();

    vetorDeProdutos[i] = nomeDoProduto;
}

Console.WriteLine("Cadastro de vendas:");

for (int linha = 0; linha < 4; linha++)
{
    Console.Clear();

    nomeDoProduto = vetorDeProdutos[linha];
    Console.WriteLine($"Vendas de: {nomeDoProduto}");

    for (int coluna = 0; coluna < 3; coluna++)
    {
        Console.WriteLine($"Digite a qtd de vendas no {coluna + 1} trimestre: "); 
        qtdVendas = int.Parse(Console.ReadLine());

        vendasTrimestrais[linha, coluna] = qtdVendas;
    }
}

// Console.Clear();

for (int linhaVendas = 0; linhaVendas < 4; linhaVendas++)
{
    nomeDoProduto = vetorDeProdutos[linhaVendas];
    Console.WriteLine($"Produto: {nomeDoProduto}");

    for (int colunaVendas = 0; colunaVendas < 3; colunaVendas++)
    {
        Console.WriteLine($"{colunaVendas + 1}º trimestre: {vendasTrimestrais[linhaVendas, colunaVendas]}");
    }  
}


