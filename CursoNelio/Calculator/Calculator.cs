namespace Calculatora
{
    public class Calculatora
    {
        public static int Sum(int n1, int n2)
        {
            return n1 + n2;
        }

        public static int Sum(int n1, int n2, int n3)
        {
            return n1 + n2 + n3;
        }

        public static int Sum(int n1, int n2, int n3, int n4)
        {
            return n1 + n2 + n3 + n4;
        }

        //Função com parametros variaveis
        public static int Sum(params int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        //modificador de parametro fora do escopo da função
        public static void Triple(ref int x)
        {
            x = x * 3;
        }

        //Out faz o paramentro ser referencia para a variavel orignal
        //nao exige que a variavel serja inicializada
        public static void TripleComOut(int origin, out int result)
        {
            result = origin * 3;
        }
    }
}