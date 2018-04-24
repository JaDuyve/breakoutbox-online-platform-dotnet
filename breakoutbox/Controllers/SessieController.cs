using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using breakoutbox.Models;
using breakoutbox.Models.Domain;
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
            return View(sessies);
        }

    }
}