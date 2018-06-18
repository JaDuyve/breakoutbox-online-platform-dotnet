﻿using BreakOutBoxAuth.Extensions;
using BreakOutBoxAuth.Models.Domain;
using BreakOutBoxAuth.Models.SessieViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BreakOutBoxAuth.Controllers
{
    public class SessieController : Controller
    {
        private readonly ISessieRepository _sessieRepository;
        private readonly SessionExtension _sessionExtension;
        
        public SessieController(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
            _sessionExtension = new SessionExtension();
        }

        // GET
        public IActionResult Index()
        {
            // Use this for development purpose
            //var sessies = _sessieRepository.GetAll();
            
            
            var sessies = _sessieRepository.GetAllActive();
            return View(new SessieViewModel(sessies));
        }

        [HttpPost]
        public IActionResult Index(string id, SessieViewModel model
        )
        {
            var sessie = _sessieRepository.GetById(id);
            if (model.Code == sessie.Code)
            {

                _sessionExtension.WriteSessieToSession(sessie, HttpContext);
                
                return RedirectToAction("Index", "Groep", new { Id = sessie.Naam }); 
            }
            TempData["error"] = "Foute Sessiecode, probeer opnieuw";
            return RedirectToAction(nameof(Index));
        }
    }
}