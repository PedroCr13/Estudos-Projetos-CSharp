using Biblioteca.Api.Common;
using Biblioteca.Api.DTOs;
using Biblioteca.Api.Mappers;
using Biblioteca.Api.Service;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditoraController : ControllerBase
    {
        private readonly EditoraService _editoraService;
        private readonly IValidator<EditoraDTO> _validador;

        public EditoraController(EditoraService editoraService, IValidator<EditoraDTO> validador)
        {
            _editoraService = editoraService;
            _validador = validador;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EditoraDTO>>> GetEditoras(int pagina = 1, int quantidade = 10)
        {
            if (pagina <= 0 || quantidade <= 0)
                return BadRequest("Parâmetro página e quantidade devem ser maiores que 0.");

            if (quantidade > 10)
                return BadRequest("O tamanho máximo da página é 10");

            var resultado = await _editoraService.ListarEditorasAsync(pagina, quantidade);

            if (resultado.Editoras == null || resultado.Editoras.Count == 0)
                return NotFound("Nenhum editora encontrada para esta página");

            var editoraDto = resultado.Editoras.Select(EditoraMapper.ToDto).ToList();

            Response.Headers.Append("X-Paginacao-TotalPaginas", resultado.TotalPaginas.ToString());
            Response.Headers.Append("X-Paginacao-PaginaAtual", pagina.ToString());

            return Ok(editoraDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EditoraDTO>> GetEditora(int id)
        {
            if (id <= 0)
                return BadRequest("O código da editora deve ser maior que 0.");

            var editora = await _editoraService.BuscaPorIdAsync(id);
            if (editora == null)
                return NotFound();
            
            var editoraDto = EditoraMapper.ToDto(editora);

            return Ok(editoraDto);
        }

        [HttpPost]
        public async Task<ActionResult<EditoraDTO>> PostEditora(EditoraDTO dto)
        { 
            var result = await _validador.ValidateAsync(dto);

            if (!result.IsValid)
            {
                var erros = new ErroResponse
                {
                    Erros = result.Errors.Select(e =>
                        new ErroItem
                        {
                            Campo = e.PropertyName,
                            Mensagem = e.ErrorMessage 
                        }).ToList()
                };
                return BadRequest(erros);
            }

            var editora = EditoraMapper.ToEntity(dto); ;
            var novaEditora = await _editoraService.CriarEditoraAsync(editora);
            var editoraDto = EditoraMapper.ToDto(novaEditora);

            return CreatedAtAction(nameof(GetEditoras), new { id = novaEditora.Id }, editoraDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditora(int id, EditoraDTO editoraDto)
        {
            var result = await _validador.ValidateAsync(editoraDto);

            if (!result.IsValid)
            {
                var erros = new ErroResponse
                {
                    Erros = result.Errors.Select(e =>
                        new ErroItem
                        {
                            Campo = e.PropertyName,
                            Mensagem = e.ErrorMessage
                        }).ToList()
                };
                return BadRequest(erros);
            }

            var editora = EditoraMapper.ToEntity(editoraDto);
            var editoraAtualizada = await _editoraService.AtualizarEditoraAsync(id, editora);

            if (!editoraAtualizada)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditora(int id)
        {
            if (id <= 0)
                return BadRequest("O ID deve ser maior do que 0.");

            var removido = await _editoraService.RemoverEditoraAsync(id);

            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
