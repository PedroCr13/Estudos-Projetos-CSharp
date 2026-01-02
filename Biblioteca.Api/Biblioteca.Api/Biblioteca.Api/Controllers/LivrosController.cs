
/*
    Verbos HTTP:
    GET = Requisição de dados ao servidor
    POST = Inclusão de dados 
    PUT = atualização de dados
    DELETE = exclusão

    Status:
    200 OK 
    204 No Content, OK sem retornar dados novamente (no PUT, DELETE)
    400 Bad Request, validação, formatação
    404 Not Found, ex. ID não encontrado na base
    500 Internal Server Error, erro interno, erro de programação
*/

using Biblioteca.Api.Models.Entities;
using Biblioteca.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly LivrosService _service;

        // o .net irá fornecer automaticamentea service (esta registrada na program)
        public LivrosController(LivrosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros(int pagina = 1, int quantidade = 10)
        {
            if (pagina <= 0 || quantidade <= 0)
                return BadRequest("Parêmtros página e quantidade devem ser maiores que 0.");

            if (quantidade > 10)
                return BadRequest("O tamanho máximo de página é 10");

            var livros = await _service.ListarLivrosAsync(pagina, quantidade);

            if (livros == null || livros.Count == 0)
                return NotFound("Nenhum livro encontrado para esta página");

            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            if (id <= 0)
                return BadRequest("O código do livro deve ser maior que 0.");

            var livro = await _service.BuscarPorIdAsync(id);
            if (livro == null)
                return NotFound();

            return Ok(livro);
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
            if (id <= 0)
                return BadRequest("O ID deve ser maior do que 0.");

            var removido = await _service.RemoverLivroAsync(id);
            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
