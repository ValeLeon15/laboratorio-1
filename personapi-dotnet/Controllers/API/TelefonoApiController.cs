using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonoApiController : ControllerBase
    {
        private readonly PersonaDbContext _context;

        public TelefonoApiController(PersonaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telefono>>> GetTelefonos()
        {
            return await _context.Telefonos.ToListAsync();
        }

        [HttpGet("{num}")]
        public async Task<ActionResult<Telefono>> GetTelefono(string num)
        {
            var telefono = await _context.Telefonos.FindAsync(num);
            if (telefono == null)
            {
                return NotFound();
            }

            return telefono;
        }

        [HttpPost]
        public async Task<ActionResult<Telefono>> PostTelefono([FromBody] Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTelefono), new { num = telefono.Num }, telefono);
        }

        [HttpPut("{num}")]
        public async Task<IActionResult> PutTelefono(string num, [FromBody] Telefono telefono)
        {
            if (num != telefono.Num)
            {
                return BadRequest();
            }

            _context.Entry(telefono).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonoExists(num))
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

        [HttpDelete("{num}")]
        public async Task<IActionResult> DeleteTelefono(string num)
        {
            var telefono = await _context.Telefonos.FindAsync(num);
            if (telefono == null)
            {
                return NotFound();
            }

            _context.Telefonos.Remove(telefono);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelefonoExists(string num)
        {
            return _context.Telefonos.Any(e => e.Num == num);
        }
    }
}
