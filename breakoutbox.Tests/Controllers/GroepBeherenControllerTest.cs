using System;
using breakoutbox.Tests.Data;
using BreakOutBoxAuth.Controllers;
using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.Domain;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Renci.SshNet;
using SQLitePCL;

namespace breakoutbox.Tests.Controllers
{
    public class GroepBeherenControllerTest
    {
        private readonly Mock<IGroepRepository> _mockGroepRepository;
        private readonly Mock<ISessieRepository> _mockSessieRepository;
        private readonly Mock<IGroepstateRepository> _mockGroepstateRepository;
        private readonly GroepBeherenController _groepBeherenController;
        private readonly DummyApplicationDbContext _dummyContext = new DummyApplicationDbContext();

        
        
        
        private readonly Sessie _sessie;
        private readonly string _sessieNaam;
        private readonly int _sessieCode;
        private readonly bool _sessieContactleer;
        private readonly DateTime _sessieStartdatum;
        private readonly string _sessieBobNaam;

        public GroepBeherenControllerTest()
        {
            _mockGroepRepository = new Mock<IGroepRepository>();
            _mockSessieRepository = new Mock<ISessieRepository>();
            _mockGroepstateRepository = new Mock<IGroepstateRepository>();
            
            _sessie = _dummyContext._maandag;
            _sessieNaam = _sessie.Naam;
            _sessieCode = _sessie.Code;
            _sessieContactleer = _sessie.Contactleer;
            _sessieStartdatum = _sessie.Startdatum;
            _sessieBobNaam = _sessie.BobNaam;
            
            
            
            _groepBeherenController = new GroepBeherenController(_mockGroepRepository.Object, _mockSessieRepository.Object, _mockGroepstateRepository.Object)
            {
                TempData = new Mock<ITempDataDictionary>().Object
            };
            
            _mockSessieRepository.Setup(s => s.GetAll()).Returns(_dummyContext.Sessies);
            _mockSessieRepository.Setup(s => s.GetById(_sessieNaam)).Returns(_dummyContext._maandag);
            

            
            

        }
    }
}