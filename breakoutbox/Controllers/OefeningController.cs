using breakoutbox.Models;
using breakoutbox.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace breakoutbox.Controllers
{
    public class OefeningController : Controller
    {
        private readonly IOefeningRepository _oefeningRepository;
        public OefeningController(IOefeningRepository oefeningRepository)
        {
            this._oefeningRepository = oefeningRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Oefening> oefeningen = _oefeningRepository.GetAll().OrderBy(o => o.Naam).ToList();
            return View(oefeningen);
        }
    }
}