using System;

/*
     Padrão Visitor: Padrão comportamental que permite separar algoritmos dos objetos nos quais eles operam

     permite adicionar novas operações as classes sem alterar as classes
     feito através de um visitante que realiza uma série de operações quando se recebe um objeto concreto
     Em uma classe de client ou produto, cria-se visitors cada visitor tem um comportamento diferente
     
*/

namespace DesignPatterns_Comportamentais.Parte2
{
    public interface IVisitor
    {
        void Visit(Engenheiro engenheiro);
        void Visit(Gerente gerente);
    }

    // Visitor (implementado)
    public class AumentaSalario : IVisitor
    {
        // Comportamentos que serão aplicados no Engenheiro e Gerente, 
        // mas não estão na classe Engenheiro e Gerente
        public void Visit(Engenheiro engenheiro)
        {
            engenheiro.Salario *= 1.10;
            Console.WriteLine($"Novo salário do engenheiro {engenheiro.Nome}: {engenheiro.Salario:C}");
        }

        public void Visit(Gerente gerente)
        {
            gerente.Salario *= 1.20;
            Console.WriteLine($"Novo salário do gerente {gerente.Nome}: {gerente.Salario:C}");
        }
    }

    public interface IEmpregado
    {
        void Accept(IVisitor visitor);
    }

    public class Engenheiro : IEmpregado
    { 
        public string Nome { get; set; }
        public double Salario { get; set; }

        public Engenheiro(string nome, double salario)
        {
            Nome = nome;
            Salario = salario;
        }

        // Engenheiro possuí metodo Accept que aceita um visitante
        // permitindo que o visitante altere seu estado interno
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Gerente : IEmpregado
    {
        public string Nome { get; set; }
        public double Salario { get; set; }

        public Gerente(string nome, double salario  )
        {
            Nome = nome;
            Salario = salario;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
