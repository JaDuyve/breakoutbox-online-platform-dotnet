﻿
using breakoutbox.Tests.Data;
using BreakOutBoxAuth.Controllers;
using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.Domain;
using BreakOutBoxAuth.Models.OefeningViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System;

namespace breakoutbox.Tests.Controllers
{
    public class GroepControllerTest
    {
        private readonly Mock<IGroepRepository> _mockGroepRepository;
        private readonly Mock<ISessieRepository> _mockSessieRepository;
        private readonly GroepController _groepController;
        private readonly DummyApplicationDbContext _dummyContext = new DummyApplicationDbContext();
        private readonly DummyApplicationDbContextFilterData _dummyContextFilter = new DummyApplicationDbContextFilterData();
        private readonly int _groepID= 8;
        private readonly Groep _testgroep;
        private readonly Sessie _maandag;
        
        public GroepControllerTest()
        {
            _mockGroepRepository = new Mock<IGroepRepository>();
            _mockSessieRepository = new Mock<ISessieRepository>();
            _groepController = new GroepController(_mockGroepRepository.Object, _mockSessieRepository.Object);
            _testgroep = new Groep
            {
                Id = 8,
                Naam = "Groep",
                Klas = "2C",
                Contactleer = true,
                Fout = 3
            };
            _maandag = new Sessie {Naam = "maandag", Code = 9999, Contactleer = true, Startdatum = new DateTime(2018, 05, 25), BobNaam = "bob" };
            _mockGroepRepository.Setup(g => g.GetById(1)).Returns(_dummyContext.GroepGemaaktVergrendeld);
            _mockGroepRepository.Setup(g => g.GetById(2)).Returns(_dummyContext.GroepBlok);
            _mockGroepRepository.Setup(g => g.GetById(3)).Returns(_dummyContext.GroepKanSpelen);
            _mockSessieRepository.Setup(c => c.GetById(_maandag.Naam)).Returns(_dummyContext._maandag);
        }
        
        [Theory]
        [InlineData(5)]
        public void Start_Pad(int id)
        {
            var result = _groepController.Start(id) as ViewResult;
            var AntwoordVm = result?.Model as AntwoordViewModel;
//            Assert.Equal(id, AntwoordVm); //Axel verbeter AUB
        }
        
        
        [Fact]
        public void Index_GetId()
        {
             var result = _groepController.Index("maandag") as ViewResult;
             var sessie = result?.Model as Sessie;
             Assert.Equal("maandag", sessie.Naam);
        }

        [Fact]
        public void StartPost_3FouteAntwoorden_RedirectsToFeedback()
        {
            if (_testgroep.Fout == 3)
            {
                var result = _groepController.Feedback(_testgroep.Id) as RedirectToActionResult;
                Assert.Equal("Feedback", result?.ActionName);
            }
            else
            {
                var result = _groepController.Start(_testgroep.Id, new AntwoordViewModel()) as RedirectToActionResult;
            }
            
        }

        [Fact]
        public void ExpiredTimer_TijdVerstreken_RedirectsToFeedback()
        {
            _testgroep.Blok();
            Assert.Equal("BLOK", _testgroep.Currentstate.GetStateEnum().ToString());
            var result = _groepController.Feedback(_testgroep.Id) as RedirectToActionResult;
            Assert.Equal("Feedback", result?.ActionName);
        }
        
        [Fact]
        public void GroepGekozenNietKunnenSpelenGaatNaarLoungeTest()
        {
            var result = _groepController.Lounge(_dummyContext.GroepGemaaktVergrendeld.Id) as ViewResult;
            var groep = result?.Model as Groep;
            Assert.Equal("Groep1", groep.Naam);
            Assert.True(groep.Currentstate.GetStateEnum() == State.GEKOZENVERGRENDELD);
        }
        [Fact]
        public void GroepGeblokkeerdGaatVanLoungeNaarFeedback()
        {
            var result = _groepController.Lounge(_dummyContext.GroepBlok.Id) as RedirectToActionResult;
            Assert.Equal("Feedback", result?.ActionName);
            Assert.Equal("Groep", result?.ControllerName);
        }

        [Fact]
        public void GroepGekozenVergrendeldGaatSpelen_lukt()
        {
            var result = _groepController.Start(_dummyContext.GroepKanSpelen.Id) as ViewResult;
            var groep = result?.Model as AntwoordViewModel;
            Assert.Equal("slecht", groep.Groep.Naam);
            Assert.True(groep.Groep.Currentstate.GetStateEnum() == State.SPELEN);
        }
    }
}