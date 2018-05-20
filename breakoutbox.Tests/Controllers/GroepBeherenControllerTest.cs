using System;
using System.Collections.Generic;
using System.Linq;
using breakoutbox.Tests.Data;
using BreakOutBoxAuth.Controllers;
using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.Domain;
using BreakOutBoxAuth.Models.SessieViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Renci.SshNet;
using SQLitePCL;
using Xunit;

namespace breakoutbox.Tests.Controllers
{
    public class GroepBeherenControllerTest
    {
        private readonly Mock<IGroepRepository> _mockGroepRepository;
        private readonly Mock<ISessieRepository> _mockSessieRepository;
        private readonly Mock<IGroepstateRepository> _mockGroepstateRepository;
        private readonly GroepBeherenController _groepBeherenController;
        private readonly DummyApplicationDbContextFilterData _dummyContext = new DummyApplicationDbContextFilterData();

        

        public GroepBeherenControllerTest()
        {
            _mockGroepRepository = new Mock<IGroepRepository>();
            _mockSessieRepository = new Mock<ISessieRepository>();
            _mockGroepstateRepository = new Mock<IGroepstateRepository>();
            
            _groepBeherenController = new GroepBeherenController(_mockGroepRepository.Object, _mockSessieRepository.Object, _mockGroepstateRepository.Object)
            {
                TempData = new Mock<ITempDataDictionary>().Object
            };
            
            _mockSessieRepository.Setup(s => s.GetAll()).Returns(_dummyContext.Sessies);
            _mockSessieRepository.Setup(s => s.GetById("maandag")).Returns(_dummyContext._maandag);
            
        }
        
        [Fact]
        public void Index_AllSessies()
        {
            var result = _groepBeherenController.Index() as ViewResult;
            var sessieView = result?.Model as ICollection<Sessie>;
            List<Sessie> sessies= sessieView.ToList();
            Assert.Equal(3, sessies.Count);
            Assert.Equal("maandag", sessies[0].Naam);
            Assert.Equal("dinsdag", sessies[1].Naam);
        }
        
        [Fact]
        public void Groepen_sessiemaandagTest()
        {
            _mockSessieRepository.Setup(s => s.GetByIdGroepenMetGroepstate("maandag")).Returns(_dummyContext._maandag);

            var result = _groepBeherenController.Groepen("maandag") as ViewResult;
            var sessie = result?.Model as Sessie;
            
            Assert.Equal(3, sessie.SessieGroep.Count);
            IList<SessieGroep> groepen = sessie.SessieGroep as List<SessieGroep>;
            Assert.Equal("Groep1", groepen[0].Groepen.Naam);
            Assert.Equal("Groep2", groepen[1].Groepen.Naam);
        }

        [Fact]
        public void DeBlokkeer_Groep_Met_BlokState_test()
        {
            _mockGroepRepository.Setup(s => s.GetById(1)).Returns(_dummyContext._groep4);
            
            var result = _groepBeherenController.DeBlokkeer(1, "maandag") as RedirectToActionResult;
            _mockGroepRepository.Verify(m => m.SaveChanges(), Times.Once());
            Assert.Equal("Groepen", result?.ActionName);
        }
        
        [Fact]
        public void DeBlokkeer_Groep_Met_StartState_test()
        {
            _mockGroepRepository.Setup(s => s.GetById(1)).Returns(_dummyContext._groep3);
            
            var result = _groepBeherenController.DeBlokkeer(1, "maandag") as RedirectToActionResult;
            _mockGroepRepository.Verify(m => m.SaveChanges(), Times.Never);
            Assert.Equal("Groepen", result?.ActionName);
        }
        
        [Fact]
        public void DeBlokeer_GroepNotFound_ReturnsNotFound()
        {
            var result = _groepBeherenController.DeBlokkeer(999, "maandag");
            Assert.IsType<NotFoundResult>(result);
        }
        
        [Fact]
        public void Groepen_SessieNotFound_ReturnsNotFound()
        {
            var result = _groepBeherenController.Groepen("OnbestaandeSessie");
            Assert.IsType<NotFoundResult>(result);
        }
        
        [Fact]
        public void GroepenActiveren_SessieNotFound_ReturnsNotFound()
        {
            var result = _groepBeherenController.GroepenActiveren("OnbestaandeSessie");
            Assert.IsType<NotFoundResult>(result);
        }
        
        
        [Fact]
        public void GroepenActiveren_Sessie_Met_NogNietActievGroepen()
        {
            _mockSessieRepository.Setup(s => s.GetByIdGroepenMetGroepstate("woensdag")).Returns(_dummyContext._woensdag);
            
            var result = _groepBeherenController.GroepenActiveren("woensdag") as RedirectToActionResult;
            _mockSessieRepository.Verify(m => m.SaveChanges(), Times.Once());
            _mockGroepstateRepository.Verify(m => m.SaveChangesAsync(), Times.Once);
            Assert.Equal("Groepen", result?.ActionName);
        }
        
        [Fact]
        public void GroepenActiveren_Sessie_Met_AlAlleGroepenActief()
        {
            _mockSessieRepository.Setup(s => s.GetByIdGroepenMetGroepstate("donderdag")).Returns(_dummyContext._donderdag);
            
            var result = _groepBeherenController.GroepenActiveren("donderdag") as RedirectToActionResult;
            _mockSessieRepository.Verify(m => m.SaveChanges(), Times.Never());
            _mockGroepstateRepository.Verify(m => m.SaveChangesAsync(), Times.Never);
            Assert.Equal("Groepen", result?.ActionName);
        }
    }
}