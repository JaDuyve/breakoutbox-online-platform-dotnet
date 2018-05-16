using BreakOutBoxAuth.Models.Domain;
using BreakOutBoxAuth.Models.SessieViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BreakOutBoxAuth.Controllers
{
    public class SessieBeherenController : Controller
    {
        private readonly ISessieRepository _sessieRepository;
        
        public SessieBeherenController(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        // GET
        [Authorize(Policy = "Admin")]
        public IActionResult Index()
        {
            var sessies = _sessieRepository.GetAll();
            return View(new SessieViewModel(sessies));
        }
        [Authorize(Policy = "Admin")]
        [HttpPost]
        public IActionResult Index(string id, SessieViewModel model
        )
        {
            var sessie = _sessieRepository.GetById(id);
            if (model.Code == sessie.Code)
            {
                
                return RedirectToAction("index", "GroepBeheren", new {Id = sessie.Naam});
            }
            return RedirectToAction(nameof(Index));
        }
    }
}