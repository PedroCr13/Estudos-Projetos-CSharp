namespace Ada.CaixaVerso.Aula.Banco
{
    public class Controle
    {
       private BancoDeContas banco;

        public Controle(BancoDeContas banco)
        {
            banco = new BancoDeContas();
        }

        private void AbrirConta()
        {
            string numConta = "";
            Console.WriteLine("Digite o numero da conta: ");
            numConta = Console.ReadLine();

            ContaBancaria conta = new ContaBancaria(numConta);

            banco.AdicionarConta(conta);

            Console.WriteLine($"Conta {conta.Numero} cadastrada!");

        }
        public void CadastrarConta() 
        {
            int qtdContasDesejadas = 0;

            Console.WriteLine("Quantas contas deseja abrir?");
            qtdContasDesejadas = int.Parse(Console.ReadLine());

            for (int i = 0; i < qtdContasDesejadas; i++)
            {
                AbrirConta();
            }

        }
    }
}