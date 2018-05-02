﻿﻿﻿using System;
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
using System.Web;

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

            if (groep.Currentstate.GetClassType() != typeof(Groepspeelstate))
            {
                groep.InitializeState();
                groep.KanSpelen();
                groep.Spelen();
                _groepRepository.SaveChanges();
            }

            Pad pad = groep.getCurrentGroepPad(groep.Progress).Paden;
            ViewData["Oefening"] = pad.OefeningNaamNavigation;
            getFile(pad.OefeningNaamNavigation.Opgave);
            return View(new AntwoordViewModel(pad, groep));
        }

        [HttpPost]
        public IActionResult Start(decimal id, AntwoordViewModel antwoordViewModel)
        {
            Groep groep = _groepRepository.GetById(id);

            if (groep == null)
            {
                return NotFound();
            }

            if (groep.Fout < 3)
            {
                if (groep.getCurrentGroepPad(groep.Progress).Paden.Antwoord.Equals(antwoordViewModel.Antwoord))
                {
                    return RedirectToAction("Action", "Groep", new {Id = groep.Id});

//                return View(new AntwoordViewModel(groep.GroepPad.ElementAt(1).Paden, groep));
                }
            }
            else
            {
                return RedirectToAction("Feedback", "Groep", new {Id = groep.Id});
            }
            
            return View(new AntwoordViewModel(groep.getCurrentGroepPad(groep.Progress).Paden, groep));

        }

        public IActionResult Feedback(decimal id)
        {
            
            Groep groep = _groepRepository.GetById(id);

            if (groep == null)
            {
                return NotFound();
            }

            return View(new ActionViewModel(groep.getCurrentGroepPad(groep.Progress).Paden, groep));
        }

        public IActionResult Action(decimal id)
        {
            Groep groep = _groepRepository.GetById(id);

            if (groep == null)
            {
                return NotFound();
            }

            return View(new ActionViewModel(groep.getCurrentGroepPad(groep.Progress).Paden, groep));
        }

        [HttpPost]
        public IActionResult Action(decimal id, ActionViewModel actionViewModel)
        {
            Groep groep = _groepRepository.GetById(id);

            if (groep == null)
            {
                return NotFound();
            }

            Pad pad = groep.getCurrentGroepPad(groep.Progress).Paden;

            if (pad.Toegangscode.Code == actionViewModel.Toegangscode)
            {
                groep.VerhoogProgress();
                _groepRepository.SaveChanges();
                
                return RedirectToAction("Start", "Groep", new {Id = groep.Id});

            }
            else
            {
                if (groep.Fout == 3)
                {
                    groep.Blok();
                    
                }
                else
                {
                    groep.VerhoogFout();
                }           
            }
            
            return View(new ActionViewModel(pad, groep));
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