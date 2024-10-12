using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
    public class TelefonoController : Controller
    {
        private readonly ITelefonoRepository _telefonoRepository;

        public TelefonoController(ITelefonoRepository telefonoRepository)
        {
            _telefonoRepository = telefonoRepository;
        }

        // GET: /Telefono/Index
        public async Task<IActionResult> Index()
        {
            var telefonos = await _telefonoRepository.GetAllAsync(); // Usa el método asíncrono para obtener todos los teléfonos
            return View(telefonos);
        }

        // GET: /Telefono/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Telefono/Create
        [HttpPost]
        public async Task<IActionResult> Create(Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                await _telefonoRepository.AddAsync(telefono); // Usa el método asíncrono para añadir el teléfono
                return RedirectToAction(nameof(Index));
            }
            return View(telefono);
        }

        // GET: /Telefono/Edit/{num}
        public async Task<IActionResult> Edit(string num)
        {
            var telefono = await _telefonoRepository.GetByIdAsync(num); // Usa el método asíncrono para obtener el teléfono por número
            if (telefono == null)
            {
                return NotFound();
            }
            return View(telefono);
        }

        // POST: /Telefono/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                await _telefonoRepository.UpdateAsync(telefono); // Usa el método asíncrono para actualizar el teléfono
                return RedirectToAction(nameof(Index));
            }
            return View(telefono);
        }

        // GET: /Telefono/Delete/{num}
        public async Task<IActionResult> Delete(string num)
        {
            var telefono = await _telefonoRepository.GetByIdAsync(num); // Usa el método asíncrono para obtener el teléfono por número
            if (telefono == null)
            {
                return NotFound();
            }
            return View(telefono);
        }

        // POST: /Telefono/Delete/{num}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string num)
        {
            await _telefonoRepository.DeleteAsync(num); // Usa el método asíncrono para eliminar el teléfono
            return RedirectToAction(nameof(Index));
        }
    }
}
