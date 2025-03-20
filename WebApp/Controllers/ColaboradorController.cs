using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColaboradorController : ControllerBase
    {
        private readonly ColaboradorRepository repository;

        public ColaboradorController(ColaboradorRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await repository.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Colaborador colaborador)
        {
            if (colaborador == null)
                return BadRequest();

            var result = await repository.InsertAsync(colaborador);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await repository.GetByIdAsync(id);
            if (result == null) return NotFound($"No se encontró un colaborador con el ID {id}");
            return Ok(result);
        }
    }
}
