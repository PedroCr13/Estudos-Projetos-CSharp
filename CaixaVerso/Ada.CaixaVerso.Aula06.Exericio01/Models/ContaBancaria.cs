namespace Ada.Caixa.Contas.Models
{
    public class ContaBancaria
    {
        protected string _numero;
        protected double _saldo;

        public string Numero
        {
            get { return _numero; }
        }
        public double Saldo
        {
           get { return _saldo; }
        }

        public ContaBancaria(string numero, double saldoInicial) 
        {
            _numero = numero;
            _saldo = saldoInicial;
        }

        public bool Depositar(double valor)
        {
            bool sucesso = false;

            if (valor > 0)
            {
                _saldo += valor;
                sucesso = true;
            }
            return sucesso;
        }

        public virtual bool Sacar(double valor) 
        {
            bool sucesso = false;

            if (valor <= _saldo) 
            {
                _saldo = _saldo - valor;
                sucesso = true;
            }
            return sucesso;
        }
    }
}