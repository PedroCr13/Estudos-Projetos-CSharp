
/*
Sua tarefa é criar a arquitetura de classes para um sistema bancário que gerencia diferentes tipos de contas, 

aplicando Herança e Sobrescrita de Métodos para especializar o comportamento. 

A classe base ContaBancaria deve ser concreta, contendo Numero e Saldo inicializados via Construtor, 
e o método Sacar(valor) deve ser marcado como virtual, contendo a lógica padrão de débito (verificando saldo). 

Posteriormente, você criará a classe ContaCorrenteEmpresarial que herdará de ContaBancaria, 
utilizando o operador : base(...) no construtor para inicializar os atributos herdados 
e adicionando um atributo específico como TaxaManutencao.

O ponto crucial do exercício reside na sobrescrita (override) do método Sacar(valor) dentro da classe ContaCorrenteEmpresarial. 

A nova lógica deve garantir que, além de subtrair o valor do saque, o sistema também debite a TaxaManutencao do saldo,
 demonstrando a especialização do comportamento herdado de forma prática e relevante ao contexto financeiro.
*/
using System.Globalization;
using Ada.Caixa.Contas.Models;
using Ada.Caixa.Contas.Controllers;
using Ada.Caixa.Contas.Data;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace Ada.Caixa.Contas.Pricipal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ContasControllers contas = new ContasControllers();

            bool continuar = true;
            int opcaoEscolhida = 0;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine(" *** Sistema Bancário *** ");
                Console.WriteLine(" 1 - Abrir conta PF");
                Console.WriteLine(" 2 - Realizar Saque Conta PF");
                Console.WriteLine(" 3 - Realizar Deposito Conta PF");
                Console.WriteLine(" 4 - Consultar Saldo Conta PF");
                Console.WriteLine(" 5 - Relatório de Contas PF");
                Console.WriteLine(" 6 - Sair");
                opcaoEscolhida = int.Parse(Console.ReadLine());

                switch (opcaoEscolhida)
                {
                    case 1:
                        contas.CadastrarContaPF();
                        break;
                    
                    case 2:
                        contas.SacarContaPF();
                        break;
                    
                    case 3:
                        contas.DepositarContaPF();
                        break;
                    
                    case 4:
                        contas.ConsultarSaldoPf();
                        break;
                    
                    case 5:
                        contas.ListarContas();
                        break;

                    case 6:
                        continuar = false;
                        break;
                    
                    default:
                        Console.WriteLine("Digite uma opção válida de 1 a 5!");
                        break;
                }
            }
        }   
    }
}