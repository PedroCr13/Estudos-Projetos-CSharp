using System;
using System.Globalization;

namespace Banco
{
    public class Conta
    {
        public int NumeroConta { get; private set; }
        public string Titular { get; set; }
        public double Saldo { get; private set; }

        public Conta(int numeroConta, string titular)
        {
            NumeroConta = numeroConta;
            Titular = titular;
            Saldo = 0.00;
        }

        public Conta(int numeroConta, string titular, double deposito)
        {
            NumeroConta = numeroConta;
            Titular = titular;
            Depositar(deposito);
        }

        public void Depositar(double valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
            }
        }

        public void Sacar(double valor)
        {
            if (Saldo > 0)
            {
                Saldo = Saldo - (valor + 5.00);
            }
        }

        public override string ToString()
        {
            return "Conta: " + NumeroConta
                + " Titular: " + Titular
                + " Saldo: " + Saldo.ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}