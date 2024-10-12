using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers.Views
{
    public class PersonaController : Controller
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        // GET: /Persona/Index
        public async Task<IActionResult> Index()
        {
            var personas = await _personaRepository.GetAllAsync(); // Usa el método asíncrono
            return View(personas);
        }

        // GET: /Persona/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Persona/Create
        [HttpPost]
        public async Task<IActionResult> Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                await _personaRepository.AddAsync(persona); // Usa el método asíncrono
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: /Persona/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var persona = await _personaRepository.GetByIdAsync(id); // Usa el método asíncrono
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: /Persona/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Persona persona)
        {
            if (ModelState.IsValid)
            {
                await _personaRepository.UpdateAsync(persona); // Usa el método asíncrono
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: /Persona/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var persona = await _personaRepository.GetByIdAsync(id); // Usa el método asíncrono
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: /Persona/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _personaRepository.DeleteAsync(id); // Usa el método asíncrono
            return RedirectToAction(nameof(Index));
        }
    }
}
