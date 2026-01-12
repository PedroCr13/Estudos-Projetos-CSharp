using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Api.Models.Entities
{
    [Table("Editoras")]
    public class Editora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? Site { get; set; }
        public string? Email { get; set; }
        public string? Observacao { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
