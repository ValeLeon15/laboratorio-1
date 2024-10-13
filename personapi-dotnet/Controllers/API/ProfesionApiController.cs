using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesionApiController : ControllerBase
    {
        private readonly PersonaDbContext _context;

        public ProfesionApiController(PersonaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesion>>> GetProfesiones()
        {
            return await _context.Profesions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profesion>> GetProfesion(int id)
        {
            var profesion = await _context.Profesions.FindAsync(id);
            if (profesion == null)
            {
                return NotFound();
            }

            return profesion;
        }

        [HttpPost]
        public async Task<ActionResult<Profesion>> PostProfesion([FromBody] Profesion profesion)
        {
            _context.Profesions.Add(profesion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfesion), new { id = profesion.Id }, profesion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesion(int id, [FromBody] Profesion profesion)
        {
            if (id != profesion.Id)
            {
                return BadRequest();
            }

            _context.Entry(profesion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesion(int id)
        {
            var profesion = await _context.Profesions.FindAsync(id);
            if (profesion == null)
            {
                return NotFound();
            }

            _context.Profesions.Remove(profesion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfesionExists(int id)
        {
            return _context.Profesions.Any(e => e.Id == id);
        }
    }
}
