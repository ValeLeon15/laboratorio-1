using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;

namespace personapi_dotnet.Controllers
{
    public class TelefonoController : Controller
    {
        private readonly ITelefonoRepository _telefonoRepository;

        public TelefonoController(ITelefonoRepository telefonoRepository)
        {
            _telefonoRepository = telefonoRepository;
        }

        public IActionResult Index()
        {
            var telefonos = _telefonoRepository.GetAll();
            return View(telefonos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                _telefonoRepository.Add(telefono);
                return RedirectToAction(nameof(Index));
            }
            return View(telefono);
        }

        public IActionResult Edit(string num)
        {
            var telefono = _telefonoRepository.GetById(num);
            return View(telefono);
        }

        [HttpPost]
        public IActionResult Edit(Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                _telefonoRepository.Update(telefono);
                return RedirectToAction(nameof(Index));
            }
            return View(telefono);
        }

        public IActionResult Delete(string num)
        {
            _telefonoRepository.Delete(num);
            return RedirectToAction(nameof(Index));
        }
    }
}
