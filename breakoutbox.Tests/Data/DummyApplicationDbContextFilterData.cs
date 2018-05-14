using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BreakOutBoxAuth.Models;

namespace breakoutbox.Tests.Data
{
    public class DummyApplicationDbContextFilterData
    {
        public  Sessie _maandag { get; }
        public  Sessie _dinsdag { get; }
        public  Sessie _woensdag { get; }

        private readonly Bob _bob;
        private readonly ICollection<BobActie> _bobActies;
        private readonly ICollection<BobOefening> _bobOefeningen;
        private readonly ICollection<Sessie> _bobSessie;

        public DummyApplicationDbContextFilterData()
        {
            _bobActies = new Collection<BobActie>();
            _bobActies.Add(new BobActie{BobNaam = "bobActie", LijstActiesNaam = "zoek aarde"});
            _bobActies.Add(new BobActie{BobNaam = "bobActie", LijstActiesNaam = "zoek lucht"});
            
            //_bobOefeningen
            
            _bob = new Bob { Naam = "bob"};
            _maandag = new Sessie {Naam = "maandag", Code = 9999, Contactleer = true, Startdatum = new DateTime(2018, 05, 25), BobNaam = "bob" };
            _dinsdag = new Sessie {Naam = "dinsdag", Code = 9999, Contactleer = true, Startdatum = new DateTime(), BobNaam = "bob" };
            _woensdag = new Sessie {Naam = "woensdag", Code = 9599, Contactleer = true, Startdatum = new DateTime(2018, 05, 4), BobNaam = "bob2" };
        }

        private DateTime getDateBeforeToday()
        {
            
            
            return DateTime.Now.AddDays(-2);
        }

        private DateTime getDateAfterToday()
        {
            return new DateTime().AddDays(4);
        }
        
        public IEnumerable<Sessie> Sessies => new List<Sessie> { _maandag, _dinsdag, _woensdag};
    }
}