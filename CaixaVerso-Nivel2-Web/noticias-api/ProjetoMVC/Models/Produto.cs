/*
Criar um site MVC, que liste produtos em uma view principal (index) como uma lista de produtos 
(tabela) e uma outra view que liste o produto como um produto a ser vendido.

Dados importantes do produto:

ID, Preço, Quantidade, Nome e Descrição

*/

namespace ProjetoMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
    }
}