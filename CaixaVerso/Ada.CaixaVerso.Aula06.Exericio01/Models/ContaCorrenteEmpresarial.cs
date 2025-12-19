namespace Ada.Caixa.Contas.Models
{
    public class ContaCorrenteEmpresarial : ContaBancaria
    {
        private double _taxaManutencao;

        public double TaxaManutencao
        {
            get {return _taxaManutencao; }
        }

        public ContaCorrenteEmpresarial(string numero, double saldoInicial, double taxaManutencao) 
            : base(numero, saldoInicial)
        {
            _taxaManutencao = taxaManutencao;
        }

        public override bool Sacar(double valor)
        {
            bool sucesso = false;
            double totalDebito = valor + _taxaManutencao;

            if (totalDebito <= _saldo)
            {
                _saldo = _saldo - totalDebito;
                sucesso = true;
            }
            return sucesso;
        }
    }
}