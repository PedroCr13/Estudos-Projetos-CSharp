using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    notas:

    Abstract Factory:
    
    Padrão criacional que permite produzir famílias de objetos relacionados sem ter
    que especificar suas classes concretas.

    Diferença:
    Factory: retorna um objeto que foi decicido
    Abstract Factory: retorna uma famlia de objetos.

    Objetos diferentes para o mesmo grupo superior.

    Definição (from Guru):
    
    O Abstract Factory é um padrão de projeto criacional que permite que você 
    produza famílias de objetos relacionados sem ter que especificar suas classes concretas.

    - Temos componentes de interface gráfica (Botão e Caixa de Texto)
    - Cada tema (Claro ou Escuro) fornece uma família completa de componentes

    A fábrica concreta garante que os objetos criados sejam compatíveis
    entre si (ex: botão claro + caixa clara).

 */

namespace DensignPatterns.Criacionais.AbstractFactory
{
    public interface IBotao
    {
        void Pintar();
    }

    public interface ICaixaTexto
    {
        void Renderizar();
    }

    // Produtos concretos para o tema Claro:
    class BotaoClaro : IBotao
    {
        public void Pintar()
        {
            Console.WriteLine("Renderizando um botão no estilo claro");
        }
    }

    class CaixaTextoClara : ICaixaTexto
    {
        public void Renderizar()
        {
            Console.WriteLine("Renderizando uma caixa de texto clara.");
        }
    }

    // Produtos concretos para tema escuro:
    class BotaoEscuro : IBotao
    {
        public void Pintar()
        {
            Console.WriteLine("Renderizando um botão no estilo escuro.");
        }
    }

    class CaixaTextoEscuro : ICaixaTexto
    {
        public void Renderizar()
        {
            Console.WriteLine("Renderizando uma caixa de texto escura.");
        }
    }

    // Interface da fábrica abstrata:
    public interface IFabricaInterfaceGrafica
    {
        IBotao CriarBotao();

        ICaixaTexto CriarCaixaTexto();
    }

    // Fabrica concreta para tema Claro:
    class FabricaTemaClaro : IFabricaInterfaceGrafica
    {
        public IBotao CriarBotao()
        {
           return new BotaoClaro();
        }

        public ICaixaTexto CriarCaixaTexto()
        {
            return new CaixaTextoClara();
        }
    }

    // Fabrica concreta para tema Escuro:
    class FabricaTemaEscuro : IFabricaInterfaceGrafica
    {
        public IBotao CriarBotao()
        {
            return new BotaoEscuro();
        }

        public ICaixaTexto CriarCaixaTexto()
        {
            return new CaixaTextoEscuro();
        }
    }

    public class Aplicacao
    {
        private IBotao _botao;
        private ICaixaTexto _caixaTexto;

        public Aplicacao(IFabricaInterfaceGrafica fabrica)
        {
            _botao = fabrica.CriarBotao();
            _caixaTexto = fabrica.CriarCaixaTexto();
        }

        public void Desenhar()
        {
            _botao.Pintar();
            _caixaTexto.Renderizar();
        }
    }
}
