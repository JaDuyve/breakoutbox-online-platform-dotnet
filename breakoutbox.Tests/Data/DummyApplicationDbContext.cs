using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using breakoutbox.Models;
using breakoutbox.Models.Domain;

namespace breakoutbox.Tests.Data
{
    public class DummyApplicationDbContext
    {
        public  Sessie _maandag { get; }
        public  Sessie _dinsdag { get; }

        private readonly Bob _bob;
        private readonly ICollection<BobActie> _bobActies;
        private readonly ICollection<BobOefening> _bobOefeningen;
        private readonly ICollection<Sessie> _bobSessie;

        public DummyApplicationDbContext()
        {
            _bobActies = new Collection<BobActie>();
            _bobActies.Add(new BobActie{BobNaam = "bobActie", LijstActiesNaam = "zoek aarde"});
            _bobActies.Add(new BobActie{BobNaam = "bobActie", LijstActiesNaam = "zoek lucht"});
            
            //_bobOefeningen
            
            _bob = new Bob { Naam = "bob"};
            _maandag = new Sessie {Naam = "maandag", Code = 9999, Contactleer = true, Startdatum = new DateTime(2018, 04, 25), BobNaam = "bob" };
            _dinsdag = new Sessie {Naam = "dinsdag", Code = 9999, Contactleer = true, Startdatum = new DateTime(2018, 04, 25), BobNaam = "bob" };

        }
        
        public IEnumerable<Sessie> Sessies => new List<Sessie> { _maandag, _dinsdag};
        
    }
}