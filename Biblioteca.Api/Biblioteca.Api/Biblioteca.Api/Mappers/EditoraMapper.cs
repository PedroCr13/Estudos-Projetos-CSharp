using Biblioteca.Api.DTOs;
using Biblioteca.Api.Models.Entities;

namespace Biblioteca.Api.Mappers
{
    public static class EditoraMapper
    {
        public static EditoraDTO ToDto(Editora editora)
        {
            return new EditoraDTO
            {
                Id = editora.Id,
                Nome = editora.Nome,
                Endereco = editora.Endereco,
                Telefone = editora.Telefone,
                Email = editora.Email,
                Site = editora.Site,
                Observacao = editora.Observacao
            };
        }

        public static Editora ToEntity(EditoraDTO dto)
        {
            return new Editora
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Endereco = dto.Endereco,
                Telefone = dto.Telefone,    
                Email = dto.Email,
                Site = dto.Site,    
                Observacao = dto.Observacao
            };
        }
    }
}
