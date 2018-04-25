using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using breakoutbox.Models;
using breakoutbox.Models.Domain;
using breakoutbox.Models.OefeningViewModel;
using Microsoft.AspNetCore.Mvc;

namespace breakoutbox.Controllers
{
    public class GroepController : Controller
    {
        private readonly IGroepRepository _groepRepository;
        private readonly ISessieRepository _sessieRepository;

        public GroepController(IGroepRepository groepRepository, ISessieRepository sessieRepository)
        {
            _groepRepository = groepRepository;
            _sessieRepository = sessieRepository;
        }

        public IActionResult Index(string id)
        {
           Sessie sessie = _sessieRepository.GetById("test");
           
            if (sessie == null)
            {
                return NotFound();
            }
            return View(sessie);
        }

        public IActionResult Start(decimal id)
        {
            Groep groep = _groepRepository.GetById(1);
            if (groep == null)
            {
                return NotFound();
            }

            ViewData["Oefening"] = groep.GroepPad.ElementAt(1).Paden.OefeningNaamNavigation;

            return View(new AntwoordViewModel(groep.GroepPad.ElementAt(1).Paden.OefeningNaamNavigation, groep.Naam));
        }

        [HttpPost]
        public IActionResult Start(long id, AntwoordViewModel antwoordViewModel)
        {
            Groep groep = _groepRepository.GetById(id);

            if (groep == null)
            {
                return NotFound();
            }

            if (groep.GroepPad.ElementAt(1).Paden.Antwoord.Equals(antwoordViewModel.Antwoord))
            {
                return View(new AntwoordViewModel(groep.GroepPad.ElementAt(1).Paden.OefeningNaamNavigation, "antwoord was goed"));
            }
            return View(new AntwoordViewModel(groep.GroepPad.ElementAt(1).Paden.OefeningNaamNavigation, "antwoord was slecht"));

        }
    }
}