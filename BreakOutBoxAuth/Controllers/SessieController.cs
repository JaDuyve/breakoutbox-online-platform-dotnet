using BreakOutBoxAuth.Models.Domain;
using BreakOutBoxAuth.Models.SessieViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BreakOutBoxAuth.Controllers
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
            var sessies = _sessieRepository.GetAll();
            return View(new SessieViewModel(sessies));
        }

        [HttpPost]
        public IActionResult Index(string id, SessieViewModel model
        )
        {
            var sessie = _sessieRepository.GetById(id);
            if (model.Code == sessie.Code)
            {
                
                return RedirectToAction("index", "Groep", new {Id = sessie.Naam});
            }
            return RedirectToAction(nameof(Index));
        }
    }
}