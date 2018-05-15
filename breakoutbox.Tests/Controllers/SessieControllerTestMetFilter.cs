//using System;
//using System.Collections.Generic;
//using System.Linq;
//using BreakOutBoxAuth.Controllers;
//using BreakOutBoxAuth.Models;
//using breakoutbox.Tests.Data;
//using BreakOutBoxAuth.Data;
//using BreakOutBoxAuth.Data.Repositories;
//using BreakOutBoxAuth.Models.Domain;
//using BreakOutBoxAuth.Models.SessieViewModel;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using Moq;
//using Xunit;
//
//namespace breakoutbox.Tests.Controllers
//{
//    public class SessieControllerTestMetFilter
//    {
//        private readonly SessieRepository _sessieRepository;
//        private readonly Mock<IdentityDbContext> _mockApplicationDbContext;
//        private readonly DummyApplicationDbContextFilterData _dummyContext = new DummyApplicationDbContextFilterData();
//        private readonly Sessie _sessie;
//        private readonly string _sessieNaam;
//
//        public SessieControllerTestMetFilter()
//        {
//            _mockApplicationDbContext = new Mock<ApplicationDbContext>();
//            _sessie = _dummyContext._maandag;
//            _sessieNaam = _sessie.Naam;
//            
//            _sessieRepository = new SessieRepository(_mockApplicationDbContext.Object)
//            {
//                TempData = new Mock<ITempDataDictionary>().Object
//            };
//
//            _mockApplicationDbContext.Setup(s => s.Sessies).Returns(_sessie);
//            _mockSessieRepository.Setup(s => s.GetById(_sessieNaam)).Returns(_dummyContext._maandag);
//            
//          
//
//        }
//        
//        [Fact]
//        public void All_SessiesFilter()
//        {
//            var result = _sessieController.Index() as ViewResult;
//            var sessieVm = result?.Model as SessieViewModel;
//            List<Sessie> sessies = sessieVm.Sessies.ToList();
////            Assert.Equal(2, sessies.Count);
//            Console.WriteLine(sessies);
////            Assert.True(sessies.Any(s => s.Naam.Equals("woensdag")));
//            Assert.False(sessies.Any(s => s.Naam.Equals("maandag")));
//            Assert.Equal(2, sessies.Count);
//        }
//    }
//}