namespace Ada.CaixaVerso.Aula04.Exercicio
{
    public class Produto 
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; } 

        public void AumentarEstoque(int qtdAumentar)
        {
            Quantidade += qtdAumentar;
        }
    }
}