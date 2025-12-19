
namespace Locacao
{
    class Quarto
    {
        public Estudante estudante { get; set; }
        public double valor { get; set; }

        public Quarto()
        {
            estudante = new Estudante();
        }
    }
}