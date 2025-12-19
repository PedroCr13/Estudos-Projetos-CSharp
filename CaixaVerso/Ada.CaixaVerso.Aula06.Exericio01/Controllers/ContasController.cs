using Ada.Caixa.Contas.Models;
using Ada.Caixa.Contas.Data;
using System.Globalization;

namespace Ada.Caixa.Contas.Controllers
{
    public class ContasControllers
    {
        private ContasBancarias _contasBancarias;
        private ContasEmpresariais _contasEmpresariais;

        public ContasControllers()
        {
            _contasBancarias = new ContasBancarias();
            _contasEmpresariais = new ContasEmpresariais();
        }    
    
        public void CadastrarContaPF()
        {
            int qtdContas = 0;
            double deposito = 0.0;
            string numeroConta = "";

            Console.Clear();
            Console.WriteLine("Abertura de conta PF");
            Console.WriteLine("Quantas contas PF deseja cadastrar?");
            qtdContas = int.Parse(Console.ReadLine());

            for (int i = 0; i < qtdContas; i++)
            {
                Console.Clear();
                Console.WriteLine("Abertura de conta PF");
                Console.WriteLine($"Cadastrando Conta {i + 1} de {qtdContas}");
                
                Console.WriteLine("Informe o numero da conta:");
                numeroConta = Console.ReadLine();

                Console.WriteLine("Informe o deposito incial:");
                deposito = double.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);

                ContaBancaria c = new ContaBancaria(numeroConta, deposito);

                _contasBancarias.Adicionar(c);
            }
            Console.WriteLine("Cadastro finalizado!");
        }

        public void CadastrarContaPJ()
        {
            int qtdContas = 0;
            double deposito = 0.0;
            double taxa = 0.0;
            string numeroConta = "";

            Console.Clear();
            Console.WriteLine("Abertura de conta PJ");
            Console.WriteLine("Quantas contas PJ deseja cadastrar?");
            qtdContas = int.Parse(Console.ReadLine());

            for (int i = 0; i < qtdContas; i++)
            {
                Console.Clear();
                Console.WriteLine("Abertura de conta PJ");
                Console.WriteLine($"Cadastrando Conta {i + 1} de {qtdContas}");
                
                Console.WriteLine("Informe o numero da conta:");
                numeroConta = Console.ReadLine();

                Console.WriteLine("Informe o deposito incial:");
                deposito = double.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);

                Console.WriteLine("Digite a taxa de manutenção:");
                taxa = double.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);

                ContaCorrenteEmpresarial c = new ContaCorrenteEmpresarial(numeroConta, deposito, taxa);

                _contasEmpresariais.Adicionar(c);
            }
            Console.WriteLine("Cadastro finalizado!");
        }

        public void DepositarContaPF()
        {
            string numeroConta = "";
            double valorDeposito = 0.0;

            Console.Clear();
            Console.WriteLine("Realizar Deposito na Conta PF");
            Console.WriteLine("Informe o numero da conta:");
            numeroConta = Console.ReadLine();

            Console.WriteLine("Quanto deseja depositar?");
            valorDeposito = double.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);

            ContaBancaria c = _contasBancarias.Consultar(new (numeroConta, 0));    

            if (c != null)
            {
               if (c.Depositar(valorDeposito))
                {
                    Console.WriteLine("Deposito realizado com sucesso!");
                } 
                else
                {
                    Console.WriteLine("Não foi possível realizar seu deposito. Verifique o valor informado.");
                }
            } 
            else
            {
                Console.WriteLine("Conta não Localizada!");
            }
            Console.WriteLine("Pressione [enter] para voltar ao menu...");
            Console.ReadKey();       
        }

        public void SacarContaPF()
        {
            string numeroConta = "";
            double valorSaque = 0.0;

            Console.Clear();
            Console.WriteLine("Realizar Saque Conta PF");
            Console.WriteLine("Informe o numero da conta:");
            numeroConta = Console.ReadLine();

            Console.WriteLine("Quanto deseja sacar?");
            valorSaque = double.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);

            ContaBancaria c = _contasBancarias.Consultar(new (numeroConta, 0));

            if (c != null)
            {
               if (c.Sacar(valorSaque))
                {
                    Console.WriteLine("Saque realizado com sucesso!");
                } 
                else
                {
                    Console.WriteLine("Não foi possível realizar seu saque!");
                }
            } 
            else
            {
                Console.WriteLine("Conta não Localizada!");
            }
            Console.WriteLine("Pressione [enter] para voltar ao menu...");
            Console.ReadKey();
        }

        public void ConsultarSaldoPf()
        {
            string numeroConta = "";
            Console.Clear();
            Console.WriteLine("Consultar Saldo de Conta PF");
            Console.WriteLine("Informe o numero da conta:");
            numeroConta = Console.ReadLine();

            ContaBancaria c = _contasBancarias.Consultar(new ContaBancaria(numeroConta, 0));

            Console.WriteLine($"\nConsultando conta nº: {c.Numero}");
            Console.WriteLine($"Saldo disponível: R$ {c.Saldo:n2}");
            Console.WriteLine("Pressione [enter] para voltar ao menu...");
            Console.ReadKey();
        }

        public void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("Relatório de Contas PF");

            foreach (ContaBancaria c in _contasBancarias.ListarContas())
            {
                Console.WriteLine($"Numero: {c.Numero} saldo: R$ {c.Saldo}");
            }

            Console.WriteLine("Pressione [enter] para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
