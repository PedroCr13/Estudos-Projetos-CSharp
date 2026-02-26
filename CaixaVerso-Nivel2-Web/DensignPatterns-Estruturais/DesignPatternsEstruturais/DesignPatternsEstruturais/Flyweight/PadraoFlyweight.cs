using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    padrão Flyweight: objetivo reaproveitar instâncias que possuem as mesmas características
    ao invés de ir alocando novas instâncias comsumindo memória.
    atua como um balanceador de memória 
    
    Exemplo: editor de texto, será reaproveitado os caracteres criados.
*/

namespace DesignPatternsEstruturais.Flyweight
{
    public interface CaractereFlyweight
    {
        void Exibir(int ponto);
    }

    public class Caractere : CaractereFlyweight
    {
        private readonly char simbolo;
        private readonly string fonte;
        public readonly int tamanho;
        private readonly ConsoleColor cor;

        public Caractere(char simbolo, string fonte, int tamanho, ConsoleColor cor    )
        {
            this.simbolo = simbolo;
            this.fonte = fonte;
            this.tamanho = tamanho;
            this.cor = cor;
        }

        public void Exibir(int ponto)
        {
            // hascode: identificador único para cada instância de objeto

            Console.ForegroundColor = cor;
            Console.WriteLine($"Caractere: {simbolo} - Fonte: {fonte}, Tamanho: {tamanho}, ponto: {ponto}, Hashcode: {GetHashCode()}");
            Console.ResetColor();
        }
    }

    public class CaractereFactory 
    {
        private Dictionary<string, Caractere> caracteres = new Dictionary<string, Caractere>();

        // verifica se a chave já existe, usa a mesma
        public Caractere GetCaractere(char chave, string fonte, int tamanho, ConsoleColor cor)
        {
            string identidade = $"{chave}-{fonte}-{tamanho}-{cor}";

            if (!caracteres.ContainsKey(identidade))
            {
                caracteres[identidade] = new Caractere(chave, fonte, tamanho,cor);
            }
            return caracteres[identidade];
        }
    }

    public class Documento
    {
        private List<CaractereFlyweight> conteudo = new List<CaractereFlyweight>();
        private CaractereFactory factory = new CaractereFactory();

        public void AdicionarCaractere(char simbolo, string fonte, int tamanho, ConsoleColor cor, int ponto)
        {
            CaractereFlyweight c = factory.GetCaractere(simbolo, fonte, tamanho, cor);
            conteudo.Add(c);
            c.Exibir(ponto);
        }
    }
}
