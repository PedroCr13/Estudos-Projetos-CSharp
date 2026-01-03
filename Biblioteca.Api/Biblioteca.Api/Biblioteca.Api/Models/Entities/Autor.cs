using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Api.Models.Entities
{
    [Table("Autores")]
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int QuantidadeLivrosVendidos { get; set; }
        public decimal ValorRecebido { get; set; }
        public string? Observacao { get; set; }
    }
}
