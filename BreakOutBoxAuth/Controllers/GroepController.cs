using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.ActionViewModel;
using BreakOutBoxAuth.Models.Domain;
using BreakOutBoxAuth.Models.OefeningViewModel;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using System.Linq;
using System.Timers;
using System.Web;
using BreakOutBoxAuth.Extensions;
using BreakOutBoxAuth.Models.LoungeViewModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Remotion.Linq.Clauses.ResultOperators;

namespace BreakOutBoxAuth.Controllers
{
    public class GroepController : Controller
    {
        private readonly IGroepRepository _groepRepository;
        private readonly SessionExtension _sessionExtension;
        private readonly ISessieRepository _sessieRepository;

        public GroepController(IGroepRepository groepRepository, ISessieRepository sessieRepository)
        {
            _groepRepository = groepRepository;
            _sessieRepository = sessieRepository;
            _sessionExtension = new SessionExtension();
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

            _sessionExtension.WriteGroepToSession(groep, HttpContext);

            if (groep.Currentstate == null)
            {
                groep.InitializeState();
                groep.GekozenEnVergrendeld();
                //groep.KanSpelen();
                //groep.Spelen();
                _groepRepository.SaveChanges();
            }
            else if (groep.Currentstate.GetStateEnum() == State.BLOK)
            {
                return RedirectToAction("Feedback", "Groep", new {Id = groep.Id});
            }


            return View(new LoungeViewModel(groep, _sessionExtension.ReadSessieFromSession(HttpContext).Naam));
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

            groep.Spelen();
            _groepRepository.SaveChanges();


            if (groep.Fout == 3)
            {
                if (groep.Contactleer)
                {
                    groep.Blok();
                    _groepRepository.SaveChanges();
                }

                return RedirectToAction("Feedback", "Groep", new {Id = groep.Id});
            }


            Pad pad = groep.getCurrentGroepPad(groep.Progress).Paden;
            ViewData["Oefening"] = pad.OefeningNaamNavigation;
            getFile(pad.OefeningNaamNavigation.Opgave);
            return View(new AntwoordViewModel(pad, groep));
        }

        public IActionResult StartDirect(decimal id)
        {
            Groep groep = _groepRepository.GetById(id);
            groep.VerhoogProgress();
            _groepRepository.SaveChanges();

            if (groep.Progress <= groep.GroepPad.Count)
            {
                return RedirectToAction("Start", "Groep", new {Id = groep.Id});
            }
            else
            {
                return View("Schatkist");
            }
        }


        [HttpPost]
        public IActionResult Start(decimal id, AntwoordViewModel antwoordViewModel)
        {
            var groep = _groepRepository.GetById(id);

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
                    if (groep.Progress <= groep.GroepPad.Count)
                    {
                        return RedirectToAction("Start", "Groep", new {Id = groep.Id});
                    }
                    else
                    {
                        return View("Schatkist");
                    }
                }
            }
            else
            {
                TempData["error"] = "Oplossing fout!";
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

        public IActionResult ExpiredTimer(decimal id)
        {
            Groep groep = _groepRepository.GetById(id);

            if (groep.Contactleer)
            {
                groep.Blok();
                _groepRepository.SaveChanges();
            }

            return RedirectToAction("Feedback", "Groep", new {Id = groep.Id});
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
                if (groep.getCurrentGroepPad(groep.Progress).Paden.ActieNaamNavigation == null)
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
            try
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
            catch (Exception e)
            {

            }
        }
    }
}