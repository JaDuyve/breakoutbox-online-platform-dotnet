using breakoutbox.Controllers;
using breakoutbox.Models.Domain;
using breakoutbox.Models.OefeningViewModel;
using breakoutbox.Tests.Data;
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
        public void Start_Correcte_Pad_Retrourt_True(int id)
        {
            var result = _groepController.Start(id) as ViewResult;
            var GroepVm = result?.Model as AntwoordViewModel;
            Assert.Equal(5, GroepVm, true);
        };
        
        [Theory]
        [InlineData(10)]
        public void Start_Fout_Pad_Retrourt_False(int id)
        {
            var result = _groepController.Start(id) as ViewResult;  
            var GroepVm = result?.Model as AntwoordViewModel;
            Assert.Equal(10, GroepVm, false);
        }
    }
}