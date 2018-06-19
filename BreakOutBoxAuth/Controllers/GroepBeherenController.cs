using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BreakOutBoxAuth.hubs;
using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.Domain;
using BreakOutBoxAuth.Models.SessieViewModel;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Differencing;

namespace BreakOutBoxAuth.Controllers
{
    public class GroepBeherenController : Controller
    {
        private readonly IGroepRepository _groepRepository;
        private readonly ISessieRepository _sessieRepository;
        private readonly IGroepstateRepository _groepstateRepository;
        private readonly AppHub _hub;
        
        public GroepBeherenController(IGroepRepository groepRepository, ISessieRepository sessieRepository,
            IGroepstateRepository groepstateRepository)
        {
            _groepRepository = groepRepository;
            _sessieRepository = sessieRepository;
            _groepstateRepository = groepstateRepository;
            
        }

        [Microsoft.AspNetCore.Authorization.Authorize(Policy = "Admin")]
        public IActionResult Index()
        {
            var sessies = _sessieRepository.GetAll();
            return View(sessies);
        }

        [Microsoft.AspNetCore.Authorization.Authorize(Policy = "Admin")]
        public IActionResult Groepen(string id)
        {
            Sessie sessie = _sessieRepository.GetByIdGroepenMetGroepstate(id);

            if (sessie == null)
            {
                return NotFound();
            }

            Groepstate state;

            foreach (var sessieGroep in sessie.SessieGroep)
            {
                if (sessieGroep.Groepen.Currentstate == null)
                {
                    sessieGroep.Groepen.InitializeState();
                }
            }

            _sessieRepository.SaveChanges();

            return View(sessie);
        }

        [Microsoft.AspNetCore.Authorization.Authorize(Policy = "Admin")]
        public IActionResult DeBlokkeer(decimal groepsId, string sessieId)
        {
            var groep = _groepRepository.GetById(groepsId);

            if (groep == null)
            {
                return NotFound();
            }

            if (groep.Currentstate.GetStateEnum() == State.BLOK)
            {
                groep.Spelen();
                groep.ResetFout();
                Groepstate state = groep.Currentstate;

                _groepRepository.SaveChanges();

                _groepstateRepository.Delete(state);
                _groepstateRepository.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Groepen), new {Id = sessieId});
        }

        [Microsoft.AspNetCore.Authorization.Authorize(Policy = "Admin")]
        public IActionResult GroepenActiveren(string sessieId)
        {
            var sessie = _sessieRepository.GetByIdGroepenMetGroepstate(sessieId);

            if (sessie == null)
            {
                return NotFound();
            }

            bool hasChanged = false;

            foreach (var sessieGroep in sessie.SessieGroep)
            {
                var state = sessieGroep.Groepen.Currentstate;
                if (sessieGroep.Groepen.Currentstate.GetStateEnum() == State.START ||
                    sessieGroep.Groepen.Currentstate.GetStateEnum() == State.GEKOZENVERGRENDELD)
                {
                    sessieGroep.Groepen.GekozenEnVergrendeld();

                    sessieGroep.Groepen.KanSpelen();
                    hasChanged = true;

                    _groepstateRepository.Delete(state);
                }
            }
 
            if (hasChanged)
            {
                _sessieRepository.SaveChanges();
                _groepstateRepository.SaveChangesAsync();

            }

            
            
            
            
            return RedirectToAction(nameof(Groepen), new {Id = sessieId});
        }
    }
}