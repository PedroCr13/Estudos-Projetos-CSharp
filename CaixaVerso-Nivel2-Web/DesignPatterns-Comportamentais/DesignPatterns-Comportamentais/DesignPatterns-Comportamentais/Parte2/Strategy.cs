using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Strategy: Padrão comportamental que permite definir uma familia de algoritmos
    colocá-los em classes separadas e fazer os objetos deles intercambiáveis

    Exemplo: possui 3 APISs de mapas, para cada situação pode usar o strategy para escolher o mapa
    mais adequado, o algoritmo de cada mapa fica encapsulado.
*/

namespace DesignPatterns_Comportamentais.Parte2
{
    public interface IRotaStrategy
    {
        void CalcularRota(string pontoA, string pontoB);
    }

    public class RotaMaisRapida : IRotaStrategy
    {
        public void CalcularRota(string pontoA, string pontoB)
        {
            Console.WriteLine($"Calculando a rota mais rápida entre {pontoA} e {pontoB}");
        }
    }

    public class RotaMaisCurta : IRotaStrategy
    {
        public void CalcularRota(string pontoA, string pontoB)
        {
            Console.WriteLine($"Calculando a rota mais curta entre {pontoA} e {pontoB}");
        }
    }

    public class RotaMaisBarata : IRotaStrategy
    {
        public void CalcularRota(string pontoA, string pontoB)
        {
            Console.WriteLine($"Calculando a rota mais barata entre {pontoA} e {pontoB}");
        }
    }

    // Context:
    public class CalculadorDeRota
    {
        private IRotaStrategy _estrategiaDeRota;

        public CalculadorDeRota(IRotaStrategy estrategia)
        {
            _estrategiaDeRota = estrategia;
        }

        public void DefinirEstrategia(IRotaStrategy estrategia)
        {
            _estrategiaDeRota = estrategia;
        }

        public void CalcularRota(string pontoA, string pontoB)
        {
            // Calcula a rota conforme a estratégia setada
            _estrategiaDeRota.CalcularRota(pontoA, pontoB);
        }
    }
}
