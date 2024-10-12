using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;

namespace personapi_dotnet.Controllers
{
    public class ProfesionController : Controller
    {
        private readonly IProfesionRepository _profesionRepository;

        public ProfesionController(IProfesionRepository profesionRepository)
        {
            _profesionRepository = profesionRepository;
        }

        public IActionResult Index()
        {
            var profesiones = _profesionRepository.GetAll();
            return View(profesiones);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Profesion profesion)
        {
            if (ModelState.IsValid)
            {
                _profesionRepository.Add(profesion);
                return RedirectToAction(nameof(Index));
            }
            return View(profesion);
        }

        public IActionResult Edit(int id)
        {
            var profesion = _profesionRepository.GetById(id);
            return View(profesion);
        }

        [HttpPost]
        public IActionResult Edit(Profesion profesion)
        {
            if (ModelState.IsValid)
            {
                _profesionRepository.Update(profesion);
                return RedirectToAction(nameof(Index));
            }
            return View(profesion);
        }

        public IActionResult Delete(int id)
        {
            _profesionRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
