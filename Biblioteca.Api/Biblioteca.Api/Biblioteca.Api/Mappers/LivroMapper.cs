using Biblioteca.Api.DTOs;
using Biblioteca.Api.Models.Entities;

namespace Biblioteca.Api.Mappers
{
    public static class LivroMapper
    {
        public static LivroDTO ToDto(Livro livro)
        {
            return new LivroDTO
            {
                Id = livro.Id,
                Nome = livro.Nome,
                Edicao = livro.Edicao,
                NumeroPagina = livro.NumeroPagina,
                Preco = livro.Preco,
                Id_editora = livro.Id_editora,
                SiteLivro = livro.SiteLivro,
                EmailAutor = livro.EmailAutor
            };
        }

        public static Livro ToEntity(LivroDTO dto)
        {
            return new Livro
            { 
                Id = dto.Id,
                Nome = dto.Nome,
                Edicao = dto.Edicao,
                NumeroPagina = dto.NumeroPagina,
                Preco = dto.Preco,
                Id_editora = dto.Id_editora,
                SiteLivro = dto.SiteLivro,
                EmailAutor = dto.EmailAutor
            };
        }
    }
}
