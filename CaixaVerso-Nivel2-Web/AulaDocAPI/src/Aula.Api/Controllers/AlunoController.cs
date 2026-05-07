using Aula.Application.Requests;
using Aula.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Aula.Api.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    [Produces("application/json")]
    [ExcludeFromCodeCoverage] // controller geralmente não testa com teste unitário
    public class AlunoController : ControllerBase
    {
        private readonly ICriarAlunoUseCase _criarAlunoUseCase;

        public AlunoController(ICriarAlunoUseCase criarAlunoUseCase)
        {
            _criarAlunoUseCase = criarAlunoUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarAlunoRequest request)
        {
            var response = await _criarAlunoUseCase.Handle(request);

            if (response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response.Data);
        }
    }
}
