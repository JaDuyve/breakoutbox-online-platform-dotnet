
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
        private readonly int _groepID= 8;
        private readonly Groep _testgroep;
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
            _mockGroepRepository.Setup(c => c.GetById(_testgroep.Id)).Returns(_dummyContext.Groep);
        }
        
        [Theory]
        [InlineData(5)]
        public void Start_Pad(int id)
        {
            var result = _groepController.Start(id) as ViewResult;
            var AntwoordVm = result?.Model as AntwoordViewModel;
//            Assert.Equal(id, AntwoordVm); //Axel verbeter AUB
        }
        
        
        [Theory]
        [InlineData("maandag")]
        [InlineData("dinsdag")]
        [InlineData("woensdag")]
        public void Index_GetId(string id)
        {
            var result = _groepController.Index(id) as ViewResult;
            var sessie = result?.Model as Sessie;
            Assert.Equal(id, sessie.Naam);
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
        public void ExpiredTimer_TijdVerstreken
        
        public IActionResult ExpiredTimer(decimal id)
        {
            Groep groep = _groepRepository.GetById(id);

            if (groep.Contactleer && groep.Currentstate.getStateEnum() != State.BLOK)
            {
                groep.Blok();
                _groepRepository.SaveChanges();    
            }  

            return RedirectToAction("Feedback", "Groep", new {Id = groep.Id});
        }
    }
}