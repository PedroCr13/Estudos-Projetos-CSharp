using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Mediator (ou Mediador, Intermediário, Intermediary, Controller 
    Padrão comportamental que permite reduzir as dependencias caóticas entre objetos
    restrige a comunicação direta entre objetos e os força a colaborar através de objeto mediador.
    reduz o acomplamento entre as classes
*/

namespace DesignPatterns_Comportamentais.Mediator
{
    public interface ITorreDeControle
    {
        void RegistrarAviao(Aviao aviao);
        void EnviarMensagem(string mensagem, Aviao aviao);
    }

    // Mediador:
    public class TorreDeControleConcreta : ITorreDeControle
    {
        private List<Aviao> _avioes = new List<Aviao>();

        public void RegistrarAviao(Aviao aviao)
        {
            _avioes.Add(aviao);
        }

        public void EnviarMensagem(string mensagem, Aviao aviaoOrigem)
        { 
            foreach (var aviao in _avioes) 
            {
                if (aviao != aviaoOrigem)
                {
                    aviao.ReceberMensagem(mensagem);
                }
            }
        }
    }

    public class Aviao
    { 
        public string Identificacao { get; private set; }
        private ITorreDeControle _torreDeControle;

        public Aviao(string id, ITorreDeControle torreDeControle)
        { 
            Identificacao = id;
            _torreDeControle = torreDeControle;
            _torreDeControle.RegistrarAviao(this);
        }

        public void EnviarMensagem(string mensagem)
        {
            Console.WriteLine($"{Identificacao} enviado mensagem: {mensagem}");
            _torreDeControle.EnviarMensagem(mensagem, this);
        }

        public void ReceberMensagem(string mensagem)
        {
            Console.WriteLine($"{Identificacao} recebeu mensagem: {mensagem}");
        }
    }
}
