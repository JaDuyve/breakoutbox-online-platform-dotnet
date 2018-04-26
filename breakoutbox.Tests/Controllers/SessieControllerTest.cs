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
    public class SessieControllerTest
    {
        private readonly SessieController _sessieController;
        private readonly Mock<ISessieRepository> _mockSessieRepository;
        private readonly DummyApplicationDbContext _dummyContext = new DummyApplicationDbContext();
        private readonly Sessie _sessie;
        private readonly string _sessieNaam;

        public SessieControllerTest()
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
            var productVm = result?.Model as SessieViewModel;
            List<Sessie> sessies = productVm.Sessies.ToList();
            Assert.Equal(2, sessies.Count);
            Assert.Equal("maandag", sessies[0].Naam);
            Assert.Equal("dinsdag", sessies[1].Naam);
        }


        [Fact]
        public void IndexHttpPost_ValidIndex_SessieCode()
        {
            var productVm = new SessieViewModel(_dummyContext._maandag.Code);
            
            _sessieController.Index("maandag", productVm);
            Assert.Equal(9999, _sessie.Code);
        }

    }
}