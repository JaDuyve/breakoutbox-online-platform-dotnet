﻿using System.Collections;
using System.Collections.Generic;
using breakoutbox.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace breakoutbox.Controllers
{
    public class GroepController : Controller
    {
        private readonly IGroepRepository _groepRepository;

        public GroepController(IGroepRepository groepRepository)
        {
            _groepRepository = groepRepository;
        }

        public IActionResult Index()
        {

            Groep groep = _groepRepository.GetById(1);
            return View(groep);
        }
    }
}