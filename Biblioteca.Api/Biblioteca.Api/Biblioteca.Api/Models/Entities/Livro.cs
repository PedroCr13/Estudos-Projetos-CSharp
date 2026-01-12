using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Api.Models.Entities
{
    [Table("livros")]
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Edicao { get; set; }
        public int NumeroPagina { get; set; }
        public decimal Preco { get; set; }
        public string? SiteLivro { get; set; }
        public string? EmailAutor { get; set; }

        [ForeignKey("Editora")]
        public int Id_editora { get; set; }
        public Editora Editora { get; set; }
    }
}
