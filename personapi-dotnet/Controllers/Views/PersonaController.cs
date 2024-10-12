using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;
using System.Collections.Generic;

namespace personapi_dotnet.Controllers.Views
{
    public class PersonaController : Controller
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public IActionResult Index()
        {
            var personas = _personaRepository.GetAll();
            return View(personas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                _personaRepository.Add(persona);
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        public IActionResult Edit(int id)
        {
            var persona = _personaRepository.GetById(id);
            return View(persona);
        }

        [HttpPost]
        public IActionResult Edit(Persona persona)
        {
            if (ModelState.IsValid)
            {
                _personaRepository.Update(persona);
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        public IActionResult Delete(int id)
        {
            _personaRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

