using Biblioteca.Api.DTOs;
using Biblioteca.Api.Models.Entities;

namespace Biblioteca.Api.Mappers
{
    public static class AutorMapper
    {
        public static AutorDTO ToDto(Autor autor)
        {
            return new AutorDTO
            {
                Id = autor.Id,
                Nome = autor.Nome,
                Email = autor.Email,
                QuantidadeLivrosVendidos = autor.QuantidadeLivrosVendidos,
                ValorRecebido = autor.ValorRecebido,
                Observacao = autor.Observacao
            };
        }

        public static Autor ToEntity(AutorDTO autor)
        {
            return new Autor
            {
                Id = autor.Id,
                Nome = autor.Nome,
                Email = autor.Email,
                QuantidadeLivrosVendidos = autor.QuantidadeLivrosVendidos,
                ValorRecebido = autor.ValorRecebido,
                Observacao = autor.Observacao
            };
        }
    }
}
