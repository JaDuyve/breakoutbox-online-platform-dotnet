using System.Collections.Generic;
using System.Linq;
using breakoutbox.Controllers;
using breakoutbox.Models;
using breakoutbox.Models.Domain;
using breakoutbox.Models.SessieViewModel;
using breakoutbox.Tests.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Xunit;

namespace breakoutbox.Tests.Controllers
{
    public class SessieControllerTestMetFilter
    {
        private readonly SessieController _sessieController;
        private readonly Mock<ISessieRepository> _mockSessieRepository;
        private readonly DummyApplicationDbContextFilterData _dummyContext = new DummyApplicationDbContextFilterData();
        private readonly Sessie _sessie;
        private readonly string _sessieNaam;

        public SessieControllerTestMetFilter()
        {
            _mockSessieRepository = new Mock<ISessieRepository>();
            _sessie = _dummyContext._maandag;
            _sessieNaam = _sessie.Naam;
            
            _sessieController = new SessieController(_mockSessieRepository.Object)
            {
                TempData = new Mock<ITempDataDictionary>().Object
            };

            _mockSessieRepository.Setup(s => s.GetAll()).Returns(_dummyContext.Sessies);
            _mockSessieRepository.Setup(s => s.GetById(_sessieNaam)).Returns(_dummyContext._maandag);
            
          

        }
        
        [Fact]
        public void Index_AllSessies()
        {
            var result = _sessieController.Index() as ViewResult;
            var sessieVm = result?.Model as SessieViewModel;
            List<Sessie> sessies = sessieVm.Sessies.ToList();
            Assert.Equal(2, sessies.Count);
//            Assert.True(co);
            Assert.Equal("dinsdag", sessies[1].Naam);
        }
    }
}