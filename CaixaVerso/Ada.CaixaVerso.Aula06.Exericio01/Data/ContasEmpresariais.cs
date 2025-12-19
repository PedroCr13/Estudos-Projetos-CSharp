using Ada.Caixa.Contas;
using Ada.Caixa.Contas.Models;

namespace Ada.Caixa.Contas.Data
{
    public class ContasEmpresariais
    {
        private List<ContaCorrenteEmpresarial> contas;

        public ContasEmpresariais()
        {
            contas = new List<ContaCorrenteEmpresarial>();
        }

        public void Adicionar(ContaCorrenteEmpresarial conta)
        {
            contas.Add(conta);
        }

        public ContaCorrenteEmpresarial Consultar(ContaCorrenteEmpresarial conta)
        {
            return contas.FirstOrDefault(c => c.Numero.Equals(conta.Numero));
        }
    }
}