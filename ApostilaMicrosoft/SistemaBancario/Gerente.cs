namespace SistemaBancario
{
    public class Gerente
    {
        public string nome { get; set; }
        public int idade { get; set; }
        public int cpf { get; set; }
        public void aprovarHorasDeFuncionarios(int cpf)
        { 
            //lógica aprovar horas
            Console.WriteLine("Horas Não aprovadas!");
        }
    }
}