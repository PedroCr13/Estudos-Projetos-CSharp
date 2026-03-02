using DesignPatterns_Comportamentais.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
     Observer: padrão comportamental que permite definir um mecanismo
     de assinatura para notificar multiplos objetos sobre quaisquer eventos
     que aconteçam com o objeto que ele eles estão observando.

     sujeito (subject) precisa notificar uma lista de objetos dependentes (observers)
     sobre qualquer mudança em seu estado (usado em eventos: interface gráfica, monitoramento, etc)
     Subscribers: apenas quem precisa saber do evento vai ouvi-lo

     Exemplo: para cada pedido realizado precisa realizar diversas ações, não manter essas ações na classe Pedidos
     para não ficar extensa, 
     usando o observer, demais sistemas (Nota Fiscal, Estoque, Brindes) obervam o evento de pedido criado para realizar as tarefas;
     também usado em filas (mensagerias), quem escuta a fila faz o processamento necessário.
*/

namespace DesignPatterns_Comportamentais.Parte2
{
    public interface IObserver
    {
        void Atualizar(Pedido pedido);
    }

    // Observador: 
    public class GeradorNF : IObserver
    {
        public void Atualizar(Pedido pedido)
        {
            Console.WriteLine($"Gerando NF para pedido: {pedido.NumeroPedido}");
        }
    }

    // Observador:
    public class SeparadorEstoque : IObserver
    {
        public void Atualizar(Pedido pedido)
        {
            Console.WriteLine($"Separando estoque para o pedido {pedido.NumeroPedido}");
        }
    }

    // Observador:
    public class EnviarBrindes : IObserver
    {
        public void Atualizar(Pedido pedido)
        {
            Console.WriteLine($"Enviado brindes para o pedido {pedido.NumeroPedido}");
        }
    }

    // Subject
    public class Pedido
    {
        public int NumeroPedido { get; set; }
        public Pedido(int numeroPedido)
        {
            NumeroPedido = numeroPedido;
        }
    }

    public class PedidoService
    { 
        public Pedido _pedido { get; private set; }
        private List<IObserver> _observers = new List<IObserver>();

        public void AdicionarObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoverObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void RealizarPedido(Pedido pedido)
        {
            _pedido = pedido;
            Console.WriteLine($"Pedido {pedido.NumeroPedido} realizado com sucesso!");
            NotificarObservers();
        }

        private void NotificarObservers()
        {
            // Cada observador fará sua respectiva ação:
            // Sem gerar acomplamento (dependência)
            foreach (var observer in _observers)
            {
                observer.Atualizar(_pedido);
            }
        }
    }
}
