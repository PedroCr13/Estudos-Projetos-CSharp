using Biblioteca.Api.Models.Context;
using Biblioteca.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Api.Service
{
    public class LivrosService
    {
        private readonly BibliotecaContext _context;

        public LivrosService(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<(List<Livro> Livros, int TotalPaginas)> ListarLivrosAsync(int pagina = 1, int quantidade = 10)
        {
            if (pagina <= 0 || quantidade <= 0 || quantidade > 10)
                return (new List<Livro>(), 0);

            var totalItens = await _context.Livros.CountAsync();
            var totalPaginas = (int)Math.Ceiling(totalItens / (double)quantidade);

            var livros = await _context.Livros
                .OrderBy(l => l.Id)
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();

            return (livros, totalItens);
        }

        public async Task<Livro?> BuscarPorIdAsync(int id)
        {
            return await _context.Livros.FindAsync(id);
        }

        public async Task<Livro> CriarLivroAsync(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
            return livro;
        }

        public async Task<bool> AtualizarLivroAsync(int id, Livro livro)
        {
            if (id != livro.Id)
                return false;

            _context.Entry(livro).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Livros.AnyAsync(l => l.Id == id))
                    return false;

                throw;
            }
        }

        public async Task<bool> RemoverLivroAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
                return false;

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return true;
        } 
    }
}
