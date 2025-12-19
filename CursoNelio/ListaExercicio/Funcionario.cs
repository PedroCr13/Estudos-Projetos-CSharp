using System.Globalization;

namespace Rh
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Salario { get; private set; }
        public Funcionario()
        {
            Nome = "";
        }

        public Funcionario(int id, string nome, double salario)
        {
            Id = id;
            Nome = nome;
            Salario = salario;
        }

        public void AumentarSalario(double porcentagem)
        {
            Salario = Salario + ((Salario * porcentagem) / 100.0);
        }
        public override string ToString()
        {
            return "Id: " + Id +
                   ", Nome: " + Nome +
                   ", Salário: " + Salario.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}