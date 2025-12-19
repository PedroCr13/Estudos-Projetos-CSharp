int numero1, numero2;

Console.WriteLine("Bem-vindo ao sistema de cálculos númericos");
Console.WriteLine("Digite o primeiro número: ");
numero1 = int.Parse(Console.ReadLine());

Console.WriteLine("");
Console.WriteLine("Digite o segundo número: ");
numero2 = int.Parse(Console.ReadLine());

if (numero1 < 0)
{
    Console.WriteLine("O priemiro numero deve ser maior que zero!");
} 
else if (numero2 < 0) 
{
    Console.WriteLine("O segundo numero deve ser maior que zero!");
} else {
    int soma = numero1 + numero2;
    int subtracao = numero1 - numero2;
    int multiplicacao = soma * subtracao;

    Console.WriteLine("A multiplicacao da soma dos numeros informados com sua subtração é : " + multiplicacao);
}