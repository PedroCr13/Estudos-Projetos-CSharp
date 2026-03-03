using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

/*
    State: padrão comportamental que permite que um objeto altere
    seu comportamento quando seu estado interno muda. 
    Parece como se o objeto mudasse de classe
    útil em máquinas de estado, onde o comportamento do sistema pode variar
*/

namespace DesignPatterns_Comportamentais.Parte2
{
    public interface IEstadoSamaforo
    {
        void ProximoEstado(Semaforo semaforo);
    }

    public class EstadoVermelho : IEstadoSamaforo
    {
        public void ProximoEstado(Semaforo semaforo)
        {
            Console.WriteLine("Semaforo Vermelho: Pare");
            Thread.Sleep(1000);
            semaforo.EstadoAtual = new EstadoVerde();
        }
    }

    public class EstadoVerde : IEstadoSamaforo
    {
        public void ProximoEstado(Semaforo semaforo)
        {
            Console.WriteLine("Semaforo Verde: Siga");
            Thread.Sleep(1000);
            semaforo.EstadoAtual = new EstadoAmarelo();
        }
    }

    public class EstadoAmarelo : IEstadoSamaforo
    {
        public void ProximoEstado(Semaforo semaforo)
        {
            Console.WriteLine("Semaforo Amarelo: Atenção");
            Thread.Sleep(1000);
            semaforo.EstadoAtual = new EstadoVermelho();
        }
    }

    public class Semaforo
    { 
        public IEstadoSamaforo EstadoAtual { get; set; }

        public Semaforo(IEstadoSamaforo estadoInicial)
        { 
           EstadoAtual = estadoInicial;
        }

        public void MudarEstado()
        {
            EstadoAtual.ProximoEstado(this);
        }
    }
}
