using System;

namespace CodeCoverageDemo
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            CpfValidation cpfValidation = new CpfValidation();

            string cpf = "051.035.860-88";
            string resultadoValdacao = cpfValidation.EhValido(cpf) ? "CPF Válido" : "CPF Inválido";

            System.Console.WriteLine(resultadoValdacao);
        }
    }
}