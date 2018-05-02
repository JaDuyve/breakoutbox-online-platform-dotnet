﻿﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using breakoutbox.Models;
  using breakoutbox.Models.ActionViewModel;
  using breakoutbox.Models.Domain;
using breakoutbox.Models.OefeningViewModel;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;

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
           Sessie sessie = _sessieRepository.GetById(id);
           
            if (sessie == null)
            {
                return NotFound();
            }
            
            
            return View(sessie);
        }

        public IActionResult Start(decimal id)
        {
            Groep groep = _groepRepository.GetById(id);
           
            if (groep == null)
            {
                return NotFound();
            }
            
            groep.KanSpelen();
            
            _groepRepository.SaveChanges();

            ViewData["Oefening"] = groep.GroepPad.ElementAt(0).Paden.OefeningNaamNavigation;
            getFile(groep.GroepPad.ElementAt(0).Paden.OefeningNaamNavigation.Opgave);
            return View(new AntwoordViewModel(groep.GroepPad.ElementAt(0).Paden, groep));
        }

        [HttpPost]
        public IActionResult Start(decimal id, AntwoordViewModel antwoordViewModel)
        {
            Groep groep = _groepRepository.GetById(id);

            if (groep == null)
            {
                return NotFound();
            }

            if (groep.GroepPad.ElementAt(0).Paden.Antwoord.Equals(antwoordViewModel.Antwoord))
            {
                return RedirectToAction("Action", "Groep", new {Id = groep.Id});

//                return View(new AntwoordViewModel(groep.GroepPad.ElementAt(1).Paden, groep));
            }
            return View(new AntwoordViewModel(groep.GroepPad.ElementAt(1).Paden, groep));

        }

        public IActionResult Action(decimal id)
        {
            Groep groep = _groepRepository.GetById(id);

            if (groep == null)
            {
                return NotFound();
            }

            
            return View(new ActionViewModel(groep.GroepPad.ElementAt(0).Paden, groep));
        }

        private void getFile(string filename)
        {
            string host = "188.166.36.83";
            string username = "bob";
            string password = "Pazaak2.0";
            string remoteDirectory = "/uploads/"; // . always refers to the current directory.

            using (Stream stream = System.IO.File.Create("./wwwroot/docs/" + filename))
            {
                using (var sftp = new SftpClient(host, username, password))
                {
                    sftp.Connect();

                    
                        sftp.DownloadFile(remoteDirectory + filename, stream);
                    

                    sftp.Disconnect();
                }
            }
        }
    }
}