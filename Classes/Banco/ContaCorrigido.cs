using System.Globalization;

namespace Banco
{
    class ContaCorrigida
    {
        public int NumeroConta { get; private set; }
        public string Titular { get; set; }
        public double Saldo { get; private set; }

        public ContaCorrigida(int numeroConta, string titular)
        {
            NumeroConta = numeroConta;
            Titular = titular;
            Saldo = 0.00;
        }
        
        public ContaCorrigida(int numeroConta, string titular, double depositoInicial) : this (numeroConta, titular)
        {
            Depositar(depositoInicial);
        }

        public void Depositar(double quantia)
        {
            Saldo += quantia;
        }

        public void Saque(double quantia)
        {
            Saldo -= quantia + 5.00;
        }

        public override string ToString()
        {
            return "Conta: " + NumeroConta
                + " Titular: " + Titular
                + " Saldo: " + Saldo.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}