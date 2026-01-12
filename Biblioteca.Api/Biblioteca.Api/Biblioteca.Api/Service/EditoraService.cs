using Biblioteca.Api.Models.Context;
using Biblioteca.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Api.Service
{
    public class EditoraService
    {
        private readonly BibliotecaContext _context;

        public EditoraService(BibliotecaContext context)
        { 
            _context = context;
        }

        public async Task<(List<Editora> Editoras, int TotalPaginas)> ListarEditorasAsync(int pagina = 1, int quantidade = 10)
        {
            if (pagina <= 0 || quantidade <= 0 || quantidade > 10)
                return (new List<Editora>(), 0);

            var TotalItens = await _context.Editoras.CountAsync();
            var TotalPaginas = (int)Math.Ceiling(TotalItens / (double)quantidade);

            var editoras = await _context.Editoras
                .OrderBy(e => e.Id)
                .Skip((pagina -1) * quantidade)
                .Take(quantidade)
                .ToListAsync();

            return (editoras, TotalPaginas);
        }

        public async Task<Editora?> BuscaPorIdAsync(int id)
        {
            return await _context.Editoras.FindAsync(id);
        }

        public async Task<Editora> CriarEditoraAsync(Editora editora)
        { 
            _context.Editoras.Add(editora);
            await _context.SaveChangesAsync();
            return editora;
        }

        public async Task<bool> AtualizarEditoraAsync(int id, Editora editora)
        {
            if (id != editora.Id)
                return false;

            _context.Entry(editora).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Editoras.AnyAsync(e => e.Id == id))
                    return false;

                throw;
            }
        }

        public async Task<bool> RemoverEditoraAsync(int id)
        {
            var editora = await _context.Editoras.FindAsync(id);
            if (editora == null)
                return false;

            _context.Editoras.Remove(editora);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
