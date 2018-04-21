using System;
using System.Collections;
using System.Collections.Generic;
using breakoutbox.Models.Domain;
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

        public IActionResult Index()
        {
            //Sessie sessie = _sessieRepository.GetById(id);
            //if (sessie == null)
           // {
           //     return NotFound();
           // }

            Groep groep = _groepRepository.GetById(1);
            if (groep == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Start));
        }

        public IActionResult Start(long id)
        {
            Groep groep = _groepRepository.GetById(id);
            if (groep == null)
            {
                return NotFound();
            }
            return View(groep);
        }
    }
}