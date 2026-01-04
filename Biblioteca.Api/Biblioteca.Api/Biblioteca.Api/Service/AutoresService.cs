using Biblioteca.Api.DTOs;
using Biblioteca.Api.Mappers;
using Biblioteca.Api.Models.Context;
using Biblioteca.Api.Models.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Api.Service
{
    public class AutoresService
    {
        private readonly BibliotecaContext _context;
        public AutoresService(BibliotecaContext context )
        {
            _context = context;
        }

        public async Task<(List<Autor> Autores, int TotalPaginas)> ListarAutoresAsync(int paginas = 1, int quantidade = 10)
        {
            if (paginas <= 0 || quantidade <= 0 || quantidade > 10)
                return (new List<Autor>(), 0);

            var totalItens = await _context.Autores.CountAsync();
            var totalPaginas = (int)Math.Ceiling(totalItens / (double)quantidade);

            var autores = await _context.Autores
                .OrderBy(a => a.Id)
                .Skip((paginas - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();

            return (autores, totalItens);
        }

        public async Task<Autor> CriarAutorAsync(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
            return autor;
        }
    }
}
