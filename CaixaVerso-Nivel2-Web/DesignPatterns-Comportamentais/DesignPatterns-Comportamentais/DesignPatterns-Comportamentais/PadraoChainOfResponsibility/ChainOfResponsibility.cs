using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    O Chain of Responsibility (cadeia de reponsabilidades) 
    é um padrão de projeto comportamental
    que permite que você passe pedidos por uma corrente de handlers
    Ao receber o pedido, cada handler decide se processa o pedido ou passa
    a diante para o próximo handler na corrente.
 
    sistema de econmenda: pedido > autenticação > encomendas
*/

namespace DesignPatterns_Comportamentais.PadraoChainOfResponsaibility
{
    public interface IAprovador
    { 
        IAprovador ProximoAprovador { get; set; }
        void ProcessarPedido(Compra compra);
    }

    public class Compra
    { 
        public int NumeroCompra { get; set; }
        public double Valor { get; set; }
        public string Finalidade { get; set; }

        public Compra(int numero, double valor, string finalidade)
        {
            NumeroCompra = numero;
            Valor = valor;
            Finalidade = finalidade;
        }
    }

    public class Gerente : IAprovador
    {
        private double _limiteAprovacao;
        public IAprovador ProximoAprovador { get; set; }
        public string Nome { get; set; }
        public Gerente(string nome, double limiteAprovacao) 
        {
            this.Nome = nome;
            _limiteAprovacao = limiteAprovacao;
        }

        public void ProcessarPedido(Compra compra)
        {
            if (compra.Valor < _limiteAprovacao)
            {
                Console.WriteLine($"{this.Nome} aprovou o pedido nº {compra.NumeroCompra} no valor de {compra.Valor:C}");
            }
            else if (ProximoAprovador != null)
            {
                // Faz o mesmo processo em cadeia...
                ProximoAprovador.ProcessarPedido(compra);
            }
            else
            {
                Console.WriteLine($"O pedido nº {compra.NumeroCompra} no valor de {compra.Valor:C} requer uma reunião executiva!");
            }
        }
    }
}
