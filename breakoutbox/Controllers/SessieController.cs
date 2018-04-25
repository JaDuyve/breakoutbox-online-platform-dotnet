using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using breakoutbox.Models;
using breakoutbox.Models.Domain;
using breakoutbox.Models.SessieViewModel;
using Microsoft.AspNetCore.Mvc;

namespace breakoutbox.Controllers
{
    public class SessieController : Controller
    {
        private readonly ISessieRepository _sessieRepository;

        public SessieController(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        // GET
        public IActionResult Index()
        {
            IEnumerable<Sessie> sessies = _sessieRepository.GetAll();
            return View(new SessieViewModel(sessies));
        }

        [HttpPost]
        public IActionResult Index(string id, SessieViewModel model
            )
        {
            Sessie sessie = _sessieRepository.GetById(id);
            if (model.Code == sessie.Code)
            {
                return RedirectToAction("index", "Groep", new { Id= sessie.Naam});
            }
            return RedirectToAction(nameof(Index));
        }
    }
}