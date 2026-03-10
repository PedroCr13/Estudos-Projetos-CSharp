using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"value{id}");
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return CreatedAtAction(nameof(Get), new { id = 3 }, value);
        }
    }
}
