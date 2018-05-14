
using breakoutbox.Tests.Data;
using BreakOutBoxAuth.Controllers;
using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.Domain;
using BreakOutBoxAuth.Models.OefeningViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace breakoutbox.Tests.Controllers
{
    public class GroepControllerTest
    {
        private readonly Mock<IGroepRepository> _mockGroepRepository;
        private readonly Mock<ISessieRepository> _mockSessieRepository;
        private readonly GroepController _groepController;
        private readonly DummyApplicationDbContext _dummyContext = new DummyApplicationDbContext();

        public GroepControllerTest()
        {
            _mockGroepRepository = new Mock<IGroepRepository>();
            _mockSessieRepository = new Mock<ISessieRepository>();
            _groepController = new GroepController(_mockGroepRepository.Object, _mockSessieRepository.Object);

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
    }
}