using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
    public class ProfesionController : Controller
    {
        private readonly IProfesionRepository _profesionRepository;

        public ProfesionController(IProfesionRepository profesionRepository)
        {
            _profesionRepository = profesionRepository;
        }

        // GET: /Profesion/Index
        public async Task<IActionResult> Index()
        {
            var profesiones = await _profesionRepository.GetAllAsync(); // Usa el método asíncrono
            return View(profesiones);
        }

        // GET: /Profesion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Profesion/Create
        [HttpPost]
        public async Task<IActionResult> Create(Profesion profesion)
        {
            if (ModelState.IsValid)
            {
                await _profesionRepository.AddAsync(profesion); // Usa el método asíncrono para añadir la profesión
                return RedirectToAction(nameof(Index));
            }
            return View(profesion);
        }

        // GET: /Profesion/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var profesion = await _profesionRepository.GetByIdAsync(id); // Usa el método asíncrono para obtener la profesión por ID
            if (profesion == null)
            {
                return NotFound();
            }
            return View(profesion);
        }

        // POST: /Profesion/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Profesion profesion)
        {
            if (ModelState.IsValid)
            {
                await _profesionRepository.UpdateAsync(profesion); // Usa el método asíncrono para actualizar la profesión
                return RedirectToAction(nameof(Index));
            }
            return View(profesion);
        }

        // GET: /Profesion/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var profesion = await _profesionRepository.GetByIdAsync(id); // Usa el método asíncrono para obtener la profesión por ID
            if (profesion == null)
            {
                return NotFound();
            }
            return View(profesion);
        }

        // POST: /Profesion/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _profesionRepository.DeleteAsync(id); // Usa el método asíncrono para eliminar la profesión
            return RedirectToAction(nameof(Index));
        }
    }
}
