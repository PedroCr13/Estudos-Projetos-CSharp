using System.ComponentModel;

namespace Ada.CaixaVerso.Aula.Banco
{
    public class BancoDeContas
    {
        private List<ContaBancaria> _contas;

        public BancoDeContas()
        {
            _contas = new List<ContaBancaria>();
        }

        public void AdicionarConta(ContaBancaria conta)
        {
            _contas.Add(conta);
        }

        public ContaBancaria BuscarConta(ContaBancaria conta)
        {
            return _contas.Find(c => c.Numero.Equals(conta.Numero));
        }
    }
}