using Biblioteca.Api.Models.Entities;
using Biblioteca.Api.Service;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly LivroService _service;

        // o .net irá fornecer automaticamentea context (program)
        public LivrosController(LivroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            return await _service.ListarLivrosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            return await _service.BuscarPorIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
            var novoLivro = await _service.CriarLivroAsync(livro);

            return CreatedAtAction(nameof(GetLivro), new { id = novoLivro.Id}, novoLivro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Livro livro)
        {
            var atualizado = await _service.AtualizarLivroAsync(id, livro);

            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            var removido = await _service.RemoverLivroAsync(id);
            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
