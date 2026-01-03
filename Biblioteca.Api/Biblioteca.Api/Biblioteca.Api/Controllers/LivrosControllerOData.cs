using Biblioteca.Api.Models.Context;
using Biblioteca.Api.Models.Entities;
using Biblioteca.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("odata/[controller]")]
    public class LivrosControllerOData : ControllerBase
    {
        private readonly LivrosService _service;

        public LivrosControllerOData(LivrosService service)
        {
            _service = service;
        }

        [HttpGet]
        public IQueryable<Livro> get()
        { 
            return _service.QueryLivros();
        }
    }
}
