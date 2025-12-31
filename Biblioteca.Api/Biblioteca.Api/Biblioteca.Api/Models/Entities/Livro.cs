namespace Biblioteca.Api.Models.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Edicao { get; set; }
        public int NumeroPagina { get; set; }
        public decimal Preco { get; set; }
        public string Editora { get; set; }
    }
}
