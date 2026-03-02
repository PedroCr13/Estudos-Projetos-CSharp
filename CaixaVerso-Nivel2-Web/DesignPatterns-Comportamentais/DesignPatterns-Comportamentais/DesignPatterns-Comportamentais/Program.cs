using DesignPatterns_Comportamentais.Command;
using DesignPatterns_Comportamentais.Iterator;
using DesignPatterns_Comportamentais.Mediator;
using DesignPatterns_Comportamentais.Memento;
using DesignPatterns_Comportamentais.PadraoChainOfResponsaibility;
using DesignPatterns_Comportamentais.Parte2;
using System;

namespace CursoAda.CaixaVerso.PadroesProjeto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Chain of Responsability
            /*
            Gerente gerente = new Gerente("Marcos", 10000);
            Gerente gerenteSenior = new Gerente("Mariana", 25000);
            Gerente diretor = new Gerente("Cecilia", 30000);

            gerente.ProximoAprovador = gerenteSenior;
            gerenteSenior.ProximoAprovador = diretor;

            Compra p1 = new Compra(1, 4000, "Materiais");
            Compra p2 = new Compra(2, 17500, "Projeto X");
            Compra p3 = new Compra(3, 75000, "Projeto Y");

            gerente.ProcessarPedido(p1);
            gerente.ProcessarPedido(p2);
            gerente.ProcessarPedido(p3);

            Console.ReadKey();
            */


            // Comannd
            /*
            Pedido pedido = new Pedido();
            Garcom garcom = new Garcom();

            garcom.SetCommand(new AdicionarItemCommand(pedido, "Hamburguer"));
            garcom.Submit();
            garcom.SetCommand(new AdicionarItemCommand(pedido, "Batata Frita"));
            garcom.Submit();

            garcom.SetCommand(new FinalizarPedidoCommand(pedido));
            garcom.Submit();

            Console.ReadKey();
            */

            // Iterator
            /*
            Biblioteca biblioteca = new Biblioteca();
            biblioteca.Add(new Livro("1984", "George Orwell"));
            biblioteca.Add(new Livro("A revolução dos bichos", "George Orwell"));
            biblioteca.Add(new Livro("Cem anos de solidão", "Gabriel Garcia Marquez"));

            IIterator<Livro> iterator = biblioteca.CreateIterator();
            while (iterator.HasNext())
            { 
                Livro livro = iterator.Next();
                Console.WriteLine($"Livro: {livro.Titulo}, autor: {livro.Autor}");
            }

            Console.ReadKey();
            */

            // Mediator
            /*
            ITorreDeControle torre = new TorreDeControleConcreta();
            Aviao aviao1 = new Aviao("Avião 1", torre);
            Aviao aviao2 = new Aviao("Avião 2", torre);
            Aviao aviao3 = new Aviao("Avião 3", torre);

            aviao1.EnviarMensagem("Solicito autorização para decolar.");
            aviao2.EnviarMensagem("Solicito autorização para pousar.");

            Console.ReadKey();
            */

            // Memento
            /*
            EditorTexto editor = new EditorTexto();
            Caretaker caretaker = new Caretaker(editor); // histórico

            editor.Conteudo = "Primeira linha de texto\n";
            caretaker.Salvar();
            editor.Conteudo = "Segunda linha de texto\n";
            caretaker.Salvar();
            editor.Conteudo += "Tereceira linha de texto\n";

            Console.WriteLine("Estado atual:");
            Console.WriteLine(editor.Conteudo);

            caretaker.Desfazer(1);

            Console.WriteLine("Estado atual:");
            Console.WriteLine(editor.Conteudo);

            Console.ReadKey();
            */

            // Observer:

            // Sistemas satélites:
            var pedidoService = new PedidoService();
            var geradorNF = new GeradorNF();
            var separadorEstoque = new SeparadorEstoque();
            var enviadorDeBrindes = new EnviarBrindes();

            // PeiddoService define os observadores:
            pedidoService.AdicionarObserver(geradorNF);
            pedidoService.AdicionarObserver(separadorEstoque);
            pedidoService.AdicionarObserver(enviadorDeBrindes);

            // ao gerar o pedido, os observadores são acionados
            var meuPedido = new DesignPatterns_Comportamentais.Parte2.Pedido(123);
            pedidoService.RealizarPedido(meuPedido);

            Console.ReadKey();

        }
    }
}