using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.Domain;
using BreakOutBoxAuth.Models.SessieViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            // Thibaut uitwerken !!!!
            
            var sessies = _sessieRepository.GetAllActive();
            return View(new SessieViewModel(sessies));
        }

        public IActionResult Groepen(string id)
        {
            Sessie sessie = _sessieRepository.GetById(id);

            if (sessie == null)
            {
                return NotFound();
            }

            return View(sessie);
        }


        public IActionResult DeBlokkeer(int groepsId, int sessieId)
        {
            var groep = _groepRepository.GetById(groepsId);

            if (groep == null)
            {
                return NotFound();
                
            }

            if (groep.Currentstate.GetClassType() == typeof(Groepgeblokkeerdstate))
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

        public IActionResult GroepenActiveren(string sessieId)
        {
            var sessie = _sessieRepository.GetByIdGroepenMetGroepstate(sessieId);

            if (sessie == null)
            {
                return NotFound();
            }

            Groepstate state;
            
            foreach (var sessieGroep in sessie.SessieGroep)
            {
                state = sessieGroep.Groepen.Currentstate;
                if (sessieGroep.Groepen.Currentstate.GetClassType() == typeof(Groepgekozenstate))
                {
                    sessieGroep.Groepen.GekozenEnVergrendeld();
                }
                sessieGroep.Groepen.KanSpelen();
                
                _groepstateRepository.Delete(state);
                
            }  
            
            _sessieRepository.SaveChanges();
            _groepstateRepository.SaveChangesAsync();
            
            
            return RedirectToAction("Index", "GroepBeheren", new {Id = sessieId});

        }
    }
}