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
            Assert.Equal(2, sessies.Count);
            Assert.Equal("maandag", sessies[0].Naam);
            Assert.Equal("dinsdag", sessies[1].Naam);
        }
        
        [Fact]
        public void Groepen()
        {
            var result = _groepBeherenController.Index() as ViewResult;
            var sessieView = result?.Model as ICollection<Sessie>;
            List<Sessie> sessies= sessieView.ToList();
            Assert.Equal(2, sessies.Count);
            Assert.Equal("maandag", sessies[0].Naam);
            Assert.Equal("dinsdag", sessies[1].Naam);
        }
        

    }
}