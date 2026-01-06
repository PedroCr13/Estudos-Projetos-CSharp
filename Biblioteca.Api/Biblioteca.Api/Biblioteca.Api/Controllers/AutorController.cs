using Biblioteca.Api.Common;
using Biblioteca.Api.DTOs;
using Biblioteca.Api.Mappers;
using Biblioteca.Api.Service;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly AutoresService _service;
        private readonly IValidator<AutorDTO> _validator;

        public AutorController(AutoresService service, IValidator<AutorDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorDTO>>> GetAutores(int pagina = 1, int quantidade = 10)
        {
            if (pagina <= 0 || quantidade <= 0)
                return BadRequest("Parêmtros página e quantidade devem ser maiores que 0.");

            if (quantidade > 10)
                return BadRequest("O tamanho máximo de página é 10");

            var resultado = await _service.ListarAutoresAsync(pagina, quantidade);

            if (resultado.Autores == null || resultado.Autores.Count == 0)
                return NotFound("Nenhum autor encontrado para esta página");

            var autorDto = resultado.Autores.Select(AutorMapper.ToDto).ToList();

            Response.Headers.Append("X-Paginacao-TotalPaginas", resultado.TotalPaginas.ToString());
            Response.Headers.Append("X-Paginacao-PaginaAtual", pagina.ToString());

            return Ok(autorDto);
        }

        [HttpPost]
        public async Task<ActionResult<AutorDTO>> PostAutor(AutorDTO dto)
        {
            // Validação do DTO com FluentValidation:
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

            var autor = AutorMapper.ToEntity(dto);
            var novoAutor = await _service.CriarAutorAsync(autor);
            var autorDto = AutorMapper.ToDto(novoAutor);

            return CreatedAtAction(nameof(GetAutores), new { id = novoAutor.Id }, autorDto);
        }
    }
}
