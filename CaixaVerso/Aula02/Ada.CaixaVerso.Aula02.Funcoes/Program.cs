MostrarMensagem();

// ListarClientesId();

Matrizes();

void MostrarMensagem()
{
    Console.WriteLine("Olá Pedro");
}

void ListarClientesId()
{
    int[] clientesId = new int[5]; // cria 5 espaços de memória

    int numDigitado = 0;

    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Indice é menor que 5? {(i < 5).ToString()}");
        Console.WriteLine("Digite um valor par ao indice " + i);
        numDigitado = int.Parse(Console.ReadLine());

        clientesId[i] = numDigitado;
    }

    foreach (int i in clientesId)
    {
        Console.WriteLine($"Valor: {i}");
    }

    for(int indice = 0; indice < 5; indice++)
    {
        Console.WriteLine($"Posicao[{indice}]: {clientesId[indice]}");
    }
}

void Matrizes()
{
    int[,] matriz = new int[3, 3];
    string[,] matrizString = new string[3, 3];

    for (int indexLinha = 0; indexLinha < 3; indexLinha++)
    {
        for (int indexColuna = 0; indexColuna < 3; indexColuna++)
        {
            Console.Clear();
            Console.WriteLine($"Digite valor para linha{indexLinha} coluna{indexColuna}: ");
            matriz[indexLinha, indexColuna] = int.Parse(Console.ReadLine());
        }
    }

    for (int i = 0; i < 3; i++)
    {
        for (int y = 0; y < 3; y++)
        {
            Console.WriteLine($"({i},{y}): {matriz[i, y]}");
        }
    }    
}

int somar(int a, int b)
{
    return a + b;
}
