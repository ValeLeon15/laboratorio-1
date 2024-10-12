using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;
using personapi_dotnet.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
    public class EstudioController : Controller
    {
        private readonly IEstudioRepository _estudioRepository;

        public EstudioController(IEstudioRepository estudioRepository)
        {
            _estudioRepository = estudioRepository;
        }

        // GET: /Estudio/Index
        public async Task<IActionResult> Index()
        {
            var estudios = await _estudioRepository.GetAllAsync();  // Obtiene todos los estudios de manera asíncrona
            return View(estudios);
        }

        // GET: /Estudio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Estudio/Create
        [HttpPost]
        public async Task<IActionResult> Create(Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                await _estudioRepository.AddAsync(estudio);  // Añade un nuevo estudio de manera asíncrona
                return RedirectToAction(nameof(Index));
            }
            return View(estudio);
        }

        // GET: /Estudio/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var estudio = await _estudioRepository.GetByIdAsync(id);  // Obtiene el estudio por su ID
            if (estudio == null)
            {
                return NotFound();
            }
            return View(estudio);
        }

        // POST: /Estudio/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                await _estudioRepository.UpdateAsync(estudio);  // Actualiza el estudio
                return RedirectToAction(nameof(Index));
            }
            return View(estudio);
        }

        // GET: /Estudio/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var estudio = await _estudioRepository.GetByIdAsync(id);  // Obtiene el estudio por su ID para eliminarlo
            if (estudio == null)
            {
                return NotFound();
            }
            return View(estudio);
        }

        // POST: /Estudio/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _estudioRepository.DeleteAsync(id);  // Elimina el estudio de manera asíncrona
            return RedirectToAction(nameof(Index));
        }
    }
}
