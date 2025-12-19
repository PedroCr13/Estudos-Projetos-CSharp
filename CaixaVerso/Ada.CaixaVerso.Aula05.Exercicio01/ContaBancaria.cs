namespace Ada.CaixaVerso.Aula.Banco
{
    public class ContaBancaria
    {
        private string _numero;
        private double _saldo;

        private bool _encerrada;

        private String _MotivoEncerramento;

        public ContaBancaria()
        {
            
        }

        public ContaBancaria(string numero)
        {
            _numero = numero;
            _saldo = 0.0;
            _encerrada = false;
            _MotivoEncerramento = "";
        }

        public string Numero
        {
            get { return _numero; }
        }
        
        public double Saldo
        {
            get {return _saldo; }
        }

        public void Depositar(double valor)
        {
            _saldo = _saldo + valor;
        }

        public bool Sacar(double valor)
        {
            bool sucesso = false;

            if (valor < 0)
            {
                return sucesso;
            }
            else if (valor < _saldo)
            {
                return sucesso;
            }
            else 
            {
                _saldo = _saldo - valor;
                return true;
            }

            return sucesso;
        }

        public bool EncerrarConta()
        {
            bool acatouEncerramento = false;

            if (_saldo == 0)
            {
                acatouEncerramento = true;
            } 

            return acatouEncerramento;
        }
    }
}