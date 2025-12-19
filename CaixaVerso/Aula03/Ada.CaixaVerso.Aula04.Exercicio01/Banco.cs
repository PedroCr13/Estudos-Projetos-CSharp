namespace Ada.CaixaVerso.Aula04.Exercicio
{
    public class Banco
    {
        private  List<Produto> produtosEmEstoque;

        public Banco()
        {
            produtosEmEstoque = new List<Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            produtosEmEstoque.Add(produto);
        }   

        public void AumentarQuantidadeProduto(int idProduto, int qtdAcrescimo)
        {
            foreach (Produto p in produtosEmEstoque)
            {
                if (p.Id == idProduto)
                {
                   p.AumentarEstoque(qtdAcrescimo);
                   Console.WriteLine($"Produto: {p.Nome} tem nova quantidade: {p.Quantidade}!");
                   break;
                }
            }
        }

        public void ListarEstoque()
        {
            foreach (Produto p in produtosEmEstoque)
            {   
                Console.WriteLine($" Produto Id: [{p.Id}]");
                Console.WriteLine($" Nome: {p.Nome}");
                Console.WriteLine($" Preço: {p.Preco}");
                Console.WriteLine($" Quantidade: {p.Quantidade}");
                Console.WriteLine(" ");
            }
        }
    }
}