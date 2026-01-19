using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Padrão Prototype:

    Permite criar objetos COPIANDO objetos já existentes "protótipos"
    
    Solução para criar objetos quando partir do zero é custoso.
    
    Clona objetos (mantendo duas instâncias diferentes)

    Definição: 

    O Prototype é um padrão de projeto criacional que permite copiar objetos existentes 
    sem fazer seu código ficar dependente de suas classes

    - Um Documento é criado como objeto original
    - A cópia é feita através do método Clone()
    - O objeto clonado é independente do original

    Alterações na cópia não afetam o objeto original,
    garantindo duas instâncias distintas.
*/

namespace DensignPatterns.Criacionais.Prototype
{
    public interface ICloneable
    {
        ICloneable Clone();
    }

    // classe concreta:
    public class Documento : ICloneable
    { 
        public string Titulo { get; set; }
        public string Conteudo { get; set; }

        public Documento(string titulo, string conteudo) 
        {
            Titulo = titulo;
            Conteudo = conteudo;
        }

        public ICloneable Clone()
        {
            return new Documento(Titulo, Conteudo);
        }

        public void Print()
        {
            Console.WriteLine($"Titulo: {Titulo}\nConteudo: {Conteudo}");
        }
    }
}
