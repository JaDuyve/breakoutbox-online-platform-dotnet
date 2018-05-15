using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.ActionViewModel;
using BreakOutBoxAuth.Models.Domain;
using BreakOutBoxAuth.Models.OefeningViewModel;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using System.Web;
using Remotion.Linq.Clauses.ResultOperators;

namespace BreakOutBoxAuth.Controllers
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
        public IActionResult Lounge(decimal id)
        {
            Groep groep = _groepRepository.GetById(id);
            if (groep == null)
            {
                return NotFound();
            }
            if (groep.Currentstate == null)
            {
                groep.InitializeState();
                groep.KanSpelen();
                groep.Spelen();
                _groepRepository.SaveChanges();
            }

            return View(groep);
        }
        public IActionResult Start(decimal id)
        {
            Groep groep = _groepRepository.GetById(id);

            if (groep == null)
            {
                return NotFound();
            }

            if (groep.Currentstate == null)
            {
                groep.InitializeState();
                groep.KanSpelen();
                groep.Spelen();
                _groepRepository.SaveChanges();
            }

            if (groep.Fout == 3)
            {
                groep.Blok();
                _groepRepository.SaveChanges();
                return RedirectToAction("Feedback", "Groep", new {Id = groep.Id});
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


            if (groep.getCurrentGroepPad(groep.Progress).Paden.Antwoord.Equals(antwoordViewModel.Antwoord))
            {
                groep.ResetFout();
                _groepRepository.SaveChanges();
                if (groep.Contactleer)
                {
                    return RedirectToAction("Action", "Groep", new {Id = groep.Id});

                }
                else
                {
                    groep.VerhoogProgress();
                    _groepRepository.SaveChanges();
                    return RedirectToAction("Start", "Groep", new {Id = groep.Id});

                }

            }
            else
            {
                if (groep.Fout == 3)
                {
                    groep.Blok();
                    _groepRepository.SaveChanges();
                    return RedirectToAction("Feedback", "Groep", new {Id = groep.Id});
                }
                else if (groep.Fout < 3)
                {
                    groep.VerhoogFout();
                    _groepRepository.SaveChanges();

                    if (groep.Fout == 3)
                    {
                        groep.Blok();
                        _groepRepository.SaveChanges();
                        return RedirectToAction("Feedback", "Groep", new {Id = groep.Id});
                    }
                }
            }

            return RedirectToAction("Start", "Groep", new {Id = groep.Id});
        }


        public IActionResult Feedback(decimal id)
        {
            Groep groep = _groepRepository.GetById(id);

            if (groep == null)
            {
                return NotFound();
            }

            string feedback = groep.getCurrentGroepPad(groep.Progress).Paden.OefeningNaamNavigation.Feedback;

            getFile(feedback);

            return View(new FeedbackViewModel(groep, feedback));
        }

        public IActionResult Action(decimal id)
        {
            Groep groep = _groepRepository.GetById(id);

            if (groep == null)
            {
                return NotFound();
            }

            if (groep.getCurrentGroepPad(groep.Progress).Paden.ActieNaamNavigation == null)
            {
                return View(new ActionViewModel(groep.getCurrentGroepPad(groep.Progress).Paden, groep, true,
                    "Zoek de schatkist"));
            }

            return View(new ActionViewModel(groep.getCurrentGroepPad(groep.Progress).Paden, groep, false));
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
                if (actionViewModel.Actie == null)
                {
                    groep.Finish();
                    _groepRepository.SaveChanges();
                    return View("Schatkist");
                }
                    
                
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

            return View(new ActionViewModel(pad, groep, false));
        }

        public IActionResult Schatkist()
        {
            return View();
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