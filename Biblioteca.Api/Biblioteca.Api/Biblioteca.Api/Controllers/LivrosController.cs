
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

using Biblioteca.Api.Common;
using Biblioteca.Api.DTOs;
using Biblioteca.Api.Mappers;
using Biblioteca.Api.Service;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly LivrosService _service;
        private readonly IValidator<LivroDTO> _validator;

        // o .net irá fornecer automaticamentea service (esta registrada na program)
        public LivrosController(LivrosService service, IValidator<LivroDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroDTO>>> GetLivros(int pagina = 1, int quantidade = 10)
        {
            if (pagina <= 0 || quantidade <= 0)
                return BadRequest("Parêmtros página e quantidade devem ser maiores que 0.");

            if (quantidade > 10)
                return BadRequest("O tamanho máximo de página é 10");

            var resultado = await _service.ListarLivrosAsync(pagina, quantidade);

            if (resultado.Livros == null || resultado.Livros.Count == 0)
                return NotFound("Nenhum livro encontrado para esta página");

            var livroDto = resultado.Livros.Select(LivroMapper.ToDto).ToList();

            Response.Headers.Append("X-Desenvolvedor", "Pedro Cristovao");
            Response.Headers.Append("X-Paginacao-TotalPaginas", resultado.TotalPaginas.ToString());
            Response.Headers.Append("X-Paginacao-PaginaAtual", pagina.ToString());

            return Ok(livroDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroDTO>> GetLivro(int id)
        {
            if (id <= 0)
                return BadRequest("O código do livro deve ser maior que 0.");

            var livro = await _service.BuscarPorIdAsync(id);
            if (livro == null)
                return NotFound();

            var livroDto = LivroMapper.ToDto(livro);

            return Ok(livroDto);
        }

        [HttpPost]
        public async Task<ActionResult<LivroDTO>> PostLivro(LivroDTO dto)
        {
            var result = await _validator.ValidateAsync(dto);

            if (!result.IsValid)
            {
                var erros = new ErroResponse
                {
                    Erros = result.Errors.Select(e => new ErroItem
                    {
                        Campo = e.PropertyName,
                        Mensagem = e.ErrorMessage

                    }).ToList()
                };
                return BadRequest(erros);
            }

            var livro = LivroMapper.ToEntity(dto);
            var novoLivro = await _service.CriarLivroAsync(livro);
            var livroDto = LivroMapper.ToDto(novoLivro);

            return CreatedAtAction(nameof(GetLivro), new { id = novoLivro.Id}, livroDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, LivroDTO livroDto)
        {
            var result = await _validator.ValidateAsync(livroDto);

            if (!result.IsValid)
            {
                var erros = new ErroResponse
                {
                    Erros = result.Errors.Select(e => new ErroItem
                    {
                        Campo = e.PropertyName,
                        Mensagem = e.ErrorMessage
                    }).ToList()
                };
                return BadRequest(erros);
            }

            var livro = LivroMapper.ToEntity(livroDto);
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
