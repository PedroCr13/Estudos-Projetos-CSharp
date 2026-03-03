using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Template Method: é um padrão comportamental que define o esqueleto de um algoritmo
    na superclasse mas deixa as subclasses sobrescreverem etapas especificas do 
    algoritmo sem modificar sua estrutura

    exemplo: ler documentos (doc, csv, pdf, json) salvos em um servidor
    para cada documento tem passos iguais, abrir igual, leitura e analisedos dados varia para cada arquivo 
*/

namespace DesignPatterns_Comportamentais.Parte2
{
    public abstract class ProcessadorDeDocumento
    {
        public void ProcessarDocumento()
        {
            AbrirDocumento();
            LerDados();
            ProcessarDados();
            SalvarDocumento();
        }

        private void AbrirDocumento()
        {
            Console.WriteLine("Documento aberto.");
        }

        protected abstract void LerDados(); // metodo template: cada subclasse fará sua implementação
        protected abstract void ProcessarDados(); // metodo template

        private void SalvarDocumento()
        {
            Console.WriteLine("Documento salvo.");
        }
    }

    public class ProcessadorPDF : ProcessadorDeDocumento
    {
        protected override void LerDados()
        {
            Console.WriteLine("Lendo dados do PDF.");
        }

        protected override void ProcessarDados()
        {
            Console.WriteLine("Processando dados do PDF.");
        }
    }

    public class ProcessadorWord : ProcessadorDeDocumento
    {
        protected override void LerDados()
        {
            Console.WriteLine("Lendo dados do word.");
        }

        protected override void ProcessarDados()
        {
            Console.WriteLine("Processando dados do Word");
        }
    }
}
