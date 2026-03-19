namespace Aula.Api.Services
{
    public class CalculadoraService
    {
        public int Somar(int a, int b)
        { 
            return a + b;
        }

        public int Subtrair(int a, int b)
        {
            return a - b;
        }

        public int Multiplicar(int a, int b)
        {
            return a * b;
        }

        public int Dividir(int a, int b)
        {
            return a / b;
        }
    }
}
