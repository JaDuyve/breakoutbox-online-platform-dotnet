using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using BreakOutBoxAuth.Models;

namespace breakoutbox.Tests.Data
{
    public class DummyApplicationDbContext
    {
        public  Sessie _maandag { get; }
        public  Sessie _dinsdag { get; }
        public  Sessie _woensdag { get; }

        private readonly Bob _bob;
        public Groep Groep { get; }
        private readonly ICollection<BobActie> _bobActies;
        private readonly ICollection<BobOefening> _bobOefeningen;
        private readonly ICollection<Sessie> _bobSessie;
        private readonly ICollection<Groep> _groeps;

        public DummyApplicationDbContext()
        {
            _bobActies = new Collection<BobActie>();
            _bobActies.Add(new BobActie {BobNaam = "bobActie", LijstActiesNaam = "zoek aarde"});
            _bobActies.Add(new BobActie {BobNaam = "bobActie", LijstActiesNaam = "zoek lucht"});

            //_bobOefeningen

            _bob = new Bob {Naam = "bob"};
            _maandag = new Sessie
            {
                Naam = "maandag",
                Code = 9999,
                Contactleer = true,
                Startdatum = new DateTime(2018, 05, 25),
                BobNaam = "bob"
            };
            _dinsdag = new Sessie
            {
                Naam = "dinsdag",
                Code = 9999,
                Contactleer = true,
                Startdatum = new DateTime(),
                BobNaam = "bob"
            };
            _woensdag = new Sessie
            {
                Naam = "woensdag",
                Code = 9599,
                Contactleer = true,
                Startdatum = new DateTime(2018, 05, 04),
                BobNaam = "bob2"
            };

//            _groeps = new Collection<Groep>();
//            _groep1 = new Groep {Contactleer = false, Currentstate = null, CurrentstateId = 1, 3,null, }

            //Groep
            Groep = new Groep
            {
                Id = 8,
                Naam = "Groep",
                Klas = "2C",
                Contactleer = true,
                Fout = 3,
                GroepPad = new GroepPad
                {
                    GroepId = 8,
                    PadenId = 1,
                    PadenKey = 0
                }
            };
        }


        private DateTime getDateBeforeToday()
        {
            return new DateTime().AddDays(-2);
        }

        private DateTime getDateAfterToday()
        {
            return new DateTime().AddDays(4);
        }
        
        public IEnumerable<Sessie> Sessies => new List<Sessie> { _maandag, _dinsdag, _woensdag};
        
    }
}