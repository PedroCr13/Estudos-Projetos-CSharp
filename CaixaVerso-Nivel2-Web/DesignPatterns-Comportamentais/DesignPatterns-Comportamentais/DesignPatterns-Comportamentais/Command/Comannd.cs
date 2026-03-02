using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
    Padrão comportamental que transforma um pedido em um 
    objeto independente que contem toda a informação sobre o pedido
    Permite encapsular informações em um objeto, possibilitando parametrizar
    e enfileirar operações
*/
namespace DesignPatterns_Comportamentais.Command
{
    public interface ICommand
    {
        void Execute();
    }

    public class Pedido
    { 
        public List<string> Itens { get; private set; } = new List<string>();

        public void AdicionarItem(string item)
        { 
            Itens.Add(item);
            Console.WriteLine($"Item adicionado: {item}");
        }

        public void FinaalizarPedido()
        {
            Console.WriteLine("Pedido finalizado com os seguintes itens:");
            foreach(var item in Itens) 
            {
                Console.WriteLine($"- {item}");
            }
        }
    }

    public class AdicionarItemCommand : ICommand 
    {
        private Pedido _pedido;
        private string _item;

        public AdicionarItemCommand(Pedido pedido, string item)
        {
            _pedido = pedido;
            _item = item;
        }

        public void Execute()
        { 
            _pedido.AdicionarItem(_item);
        }
    }

    public class FinalizarPedidoCommand : ICommand
    {
        private Pedido _pedido;

        public FinalizarPedidoCommand(Pedido pedido)
        { 
            _pedido = pedido;
        }

        public void Execute()
        {
            _pedido.FinaalizarPedido();
        }
    }

    public class Garcom
    {
        private ICommand _comand;

        public void SetCommand(ICommand comando)
        { 
            _comand = comando;
        }

        public void Submit()
        {
            if (_comand != null)
            { 
                _comand.Execute();
            }
        }
    }
}
