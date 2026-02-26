using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


/*
    Padrão Brigde é um padrão de projeto estrutural que permite dividir 
    uma classe grande em um conjunto de classes intimamente ligadas em duas
    hierarquias separadas - abstração e implementação 
    que podem ser desenvolvidas independentes umas das outras
 
    Classe envia mensagem Email ou SMS, para o programa principal é indiferente a forma que será enviada
*/

namespace DesignPatternsEstruturais.Bridge
{
    public interface IMessageSender
    {
        void SendMessage(string subject, string body);
    }

    // implementações concreteas:
    public class EmailSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine($"Email enviado: assunto: {subject}, corpo: {body}");
        }
    }

    public class SmsSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine($"Sms enviado: assunto: {subject}, mensagem: {body}");
        }
    }

    // Abstração:
    public abstract class Message
    {
        protected IMessageSender messageSender;

        public Message(IMessageSender sender)
        {
            messageSender = sender;
        }

        public abstract void Send(string subject, string body);
    }

    // user e admin indiferente será enviada por email ou sms
    public class UserMessage : Message
    {
        public UserMessage(IMessageSender sender) : base(sender) { }

        public override void Send(string subject, string body)
        {
            Console.WriteLine($"Enviado mensagem ao usuário...");
            messageSender.SendMessage(subject, body);
        }
    }

    public class AdminMessage : Message
    {
        public AdminMessage(IMessageSender sender) : base(sender)
        {
        }

        public override void Send(string subject, string body)
        {
            Console.WriteLine("Enviando mensagem de administração...");
            messageSender.SendMessage(subject, body);
        }
    }
}
