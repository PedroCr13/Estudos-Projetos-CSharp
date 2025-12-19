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
            Console.WriteLine("=================================");
            Console.WriteLine("CCCC    AA     I X    X     AA    ");
            Console.WriteLine("C      A  A       X  X     A  A  ");
            Console.WriteLine("C      AAAAA   I    X      AAAA  ");
            Console.WriteLine("C     A     A  I   X  X   A    A ");
            Console.WriteLine("CCCC  A     A  I  X    X  A    A ");
            Console.WriteLine("=================================");
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

            /*
            Console.WriteLine("Digite o numero da conta: ");
            string numeroDaConta = Console.ReadLine();

            ContaBancaria conta01 = new ContaBancaria(numeroDaConta);

            Console.WriteLine("Quanto deseja depositar?");
            valor = double.Parse(Console.ReadLine());

            conta01.Depositar(valor);

            Console.WriteLine($"Conta Numero: {conta01.Numero}");
            Console.WriteLine($"Saldo Atual: {conta01.Saldo}");

            Console.WriteLine("Qual o valor deseja sacar?");
            valor = double.Parse(Console.ReadLine());

            if (conta01.Sacar(valor))
            {
                Console.WriteLine($"Saque realizado com sucesso! Seu novo saldo é {conta01.Saldo}");    
            } 
            else
            {
                Console.WriteLine("Não foi possível realizar o saque!");
            }
            */
        }
    }
}