using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Api.DTOs
{
    public class LivroDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(200, ErrorMessage = "Nome não pode ultrapassar 200 caracterres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Necessário informar edição deste livro.")]
        public string Edicao { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Numero de páginas deve estar entre {1} e {2}")]
        public int NumeroPagina { get; set; }
        public decimal Preco { get; set; }
        public int Id_editora { get; set; }

        [Url(ErrorMessage = "Esse campo deve ser uma URL válida.")]
        public string? SiteLivro { get; set; }

        [EmailAddress(ErrorMessage = "Necessário email válido.")]
        public string? EmailAutor { get; set; }
    }
}
