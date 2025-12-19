
// Variáveis é tudo que vai receber ou armazenar valores
// numeros inteiros (int), se sao decimais (decimal) Texto (string)


using System.Reflection;

Console.WriteLine("Bem ao sistema de Calculos Numericos");
Console.WriteLine("Digite o primeiro númeoro: ");
int numero1 = int.Parse(Console.ReadLine());

Console.WriteLine("Digite o segundo númeoro: ");
int numero2 = int.Parse(Console.ReadLine());

int resultadoSoma = numero1 + numero2;

Console.WriteLine($"A soma de  {numero1} + {numero2} = {resultadoSoma}");



