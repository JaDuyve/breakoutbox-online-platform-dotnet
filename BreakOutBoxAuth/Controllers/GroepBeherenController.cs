using System.Text.RegularExpressions;
using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BreakOutBoxAuth.Controllers
{
    public class GroepBeherenController : Controller
    {
        private readonly IGroepRepository _groepRepository;
        private readonly ISessieRepository _sessieRepository;
        private readonly IGroepstateRepository _groepstateRepository;

        public GroepBeherenController(IGroepRepository groepRepository, ISessieRepository sessieRepository, IGroepstateRepository groepstateRepository)
        {
            _groepRepository = groepRepository;
            _sessieRepository = sessieRepository;
            _groepstateRepository = _groepstateRepository;
        }
        
        public IActionResult Index(string id)
        {
            Sessie sessie = _sessieRepository.GetById(id);

            if (sessie == null)
            {
                return NotFound();
            }

            return null;
//            return View(sessie);
        }


        public IActionResult DeBlokkeer(int groepsId, int sessieId)
        {
            var groep = _groepRepository.GetById(groepsId);

            if (groep == null)
            {
                return NotFound();
                
            }

            if (groep.Currentstate.GetType() == typeof(Groepgeblokkeerdstate))
            {

                groep.Spelen();
                groep.ResetFout();
                Groepstate state = groep.Currentstate;

                _groepRepository.SaveChangesAsync();

                _groepstateRepository.Delete(state);
                _groepstateRepository.SaveChangesAsync();

            }

            return RedirectToAction("Index", "GroepBeheren", new {Id = sessieId});

        }
    }
}