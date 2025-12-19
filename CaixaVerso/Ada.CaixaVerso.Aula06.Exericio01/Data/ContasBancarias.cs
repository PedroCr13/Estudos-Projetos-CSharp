using Ada.Caixa.Contas;
using Ada.Caixa.Contas.Models;

namespace Ada.Caixa.Contas.Data
{
    public class ContasBancarias
    {
        private List<ContaBancaria> contas;

        public ContasBancarias()
        {
            contas = new List<ContaBancaria>();
        }

        public void Adicionar(ContaBancaria conta)
        {
            contas.Add(conta);
        }

        public ContaBancaria Consultar(ContaBancaria conta)
        {
            return contas.FirstOrDefault(c => c.Numero.Equals(conta.Numero));
        }

        public bool Sacar(ContaBancaria conta, double valor)
        {
            ContaBancaria c = contas.FirstOrDefault(c => c.Numero.Equals(conta.Numero));
            return c.Sacar(valor);
        }

        public List<ContaBancaria> ListarContas()
        {
            return contas;
        }
    }
}