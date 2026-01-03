namespace Biblioteca.Api.DTOs
{
    public class AutorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int QuantidadeLivrosVendidos { get; set; }
        public decimal ValorRecebido { get; set; }
        public string Observacao { get; set; }
    }
}
