using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

/*
    Anotações:

    Padrão Factory: Define uma interface (classe abstrata)
    deixa as subclasses decidirem qual a subclasse será instanciada.
    vários objetos para serem criados, dependendo de uma condição externa.
    
    exemplos:
    logistica => logistica Rodoviária / logistica Maritima 
    
    mensagens para clientes: adimplentes, inadimplentes, inadimplentes mais 30 dias, inadimplentes 40 dias...

    Definição (site RefactoringGuru)
 
    O Factory Method é um padrão criacional de projeto que fornece uma interface para criar objetos em uma superclasse,
    mas permite que as subclasses alterem o tipo de objetos que serão criados.

    Aqui a classe CriadorDeLog define o método abstrato CriarLog().
    As subclasses (CriadorLogSimples e CriadorLogDetalhado) decidem
    qual tipo de log será criado.

    O código cliente (Program.cs):
    - Não conhece as classes concretas de log
    - Trabalha apenas com a abstração (ILog)
*/

namespace DensignPatterns.Criacionais.Factory
{
    // Inteface:
    public interface ILog
    {
        void EscreverLog(string mensagem);
    }

    // Classes concretas que implementam inteface:

    public class SimpleLog : ILog
    {
        public void EscreverLog(string message)
        {
            Console.WriteLine($"SimpleLog: {message}");
        }
    }

    public class DetailedLog : ILog
    {
        public void EscreverLog(string message)
        {
            Console.WriteLine($"DetailedLog [{DateTime.Now}]: {message}");
        }
    }

    public abstract class CriadorDeLog
    {
        public abstract ILog CriarLog();

        public void LogMessage(string message)
        { 
            var log = CriarLog();
            log.EscreverLog(message);
        }
    }

    public class CriadorLogSimples : CriadorDeLog
    {
        public override ILog CriarLog()
        {
            return new SimpleLog();
        }
    }

    public class CriadorLogDetalhado : CriadorDeLog
    {
        public override ILog CriarLog()
        {
            return new DetailedLog();
        }
    }
}

