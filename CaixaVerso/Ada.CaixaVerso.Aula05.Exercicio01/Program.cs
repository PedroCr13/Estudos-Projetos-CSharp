/*
    Sua tarefa é criar a classe ContaBancaria aplicando rigorosamente o Encapsulamento para garantir a integridade dos dados.
    A classe deve possuir atributos de campo (_numeroConta e _saldo) estritamente private. 
    O Construtor é obrigatório e deve inicializar a conta com um número e saldo zero. 
    O acesso aos dados deve ser feito através de Propriedades, 
    e todas as alterações no saldo devem ser realizadas exclusivamente por Métodos públicos (Depositar(valor) e Sacar(valor)). 
    Estes métodos são a única porta de entrada para a lógica de negócio, 
    devendo validar se o valor é positivo e se há saldo suficiente para o saque, respectivamente, 
    reforçando a proteção do estado interno da classe.
*/
using System.Runtime.InteropServices;

namespace Ada.CaixaVerso.Aula.Banco
{
    public class Program
    {
        public void EscreverLogo()
        {
            Console.WriteLine("Banco");
        }

        static void Main(string[] args)
        {
            BancoDeContas banco = new BancoDeContas();
            Controle controle = new Controle(banco);

            double valor = 0.0;
            bool continuar = true;
            int opcaoSelecionada = 0;

            while (continuar) {
                Console.WriteLine("");
                Console.WriteLine("1 - Abrir Conta");
                Console.WriteLine("2 - Realizar Depósito");
                Console.WriteLine("3 - Realizar Saque");
                Console.WriteLine("4 - Consultar Saldo");
                Console.WriteLine("5 - Sair do sistema");

                Console.WriteLine("Escolha uma opção:");
                opcaoSelecionada = int.Parse(Console.ReadLine());

                if (opcaoSelecionada == 1)
                {
                    Console.Clear();
                    Console.WriteLine(" *** Abertura de Conta ***");
                    controle.CadastrarConta();
                } 
                else if (opcaoSelecionada == 2)
                {
                    Console.Clear();  
                    Console.WriteLine(" *** Realizar Deposito ***"); 
                }
                else if (opcaoSelecionada == 3)
                {
                    Console.Clear();
                    Console.WriteLine(" *** Realizar Sarque ***"); 
                } 
                else if (opcaoSelecionada == 4)
                {
                    Console.Clear();
                    Console.WriteLine(" *** Consultar Saldo ***"); 
                } 
                else if (opcaoSelecionada == 5)
                {
                    continuar = false;
                }
            }
        }
    }
}