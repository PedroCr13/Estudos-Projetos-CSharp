using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Decorator: padrão de projeto estrutural que permite acomplar  
    novos comportamentos para objetos ao colocá-los dentro de involucros
    de objetos que contem os comportamentos

    alterar o comportamento das classes sem aterá-las
    alternativa a herança para estender funcionalidades de uma classe
    
 */

namespace DesignPatternsEstruturais.Decorator
{
    public abstract class Bebida
    {
        public virtual string Descricao { get; protected set; } = "Bebida desconhecida";
        public abstract double Custo();
    }

    public class Cafe : Bebida
    { 
        public Cafe() 
        {
            Descricao = "Café";
        }

        public override double Custo()
        {
            return 1.99;
        }
    }

    // Decorador:
    public abstract class DecoradorDeCondimento : Bebida
    {
        public abstract override string Descricao {get; }
    }

    // Decorador concreto:
    public class Leite : DecoradorDeCondimento
    {
        private Bebida bebida;

        public Leite(Bebida bebida)
        {
            this.bebida = bebida;
        }

        public override string Descricao => bebida.Descricao + ", Leite";

        public override double Custo()
        {
            return bebida.Custo() + 0.50;
        }
    }

    public class Chantily : DecoradorDeCondimento
    {
        private Bebida bebida;

        public Chantily(Bebida bebida   )
        {
            this.bebida = bebida;
        }

        public override string Descricao => bebida.Descricao + ", Chantily";

        public override double Custo()
        {
            return bebida.Custo() + 0.70;
        }
    }
}
