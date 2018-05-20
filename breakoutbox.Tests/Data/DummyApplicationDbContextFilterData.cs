﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.Domain;

namespace breakoutbox.Tests.Data
{
    public class DummyApplicationDbContextFilterData
    {
        public Sessie _maandag { get; }
        public Sessie _dinsdag { get; }
        public Sessie _woensdag { get; }
        public Sessie _donderdag { get; }

        public Groep _groep1 { get; }
        public Groep _groep2 { get; }
        public Groep _groep3 { get; }
        public Groep _groep4 { get; }

        public Groep _groep1Donderdag { get; }
        public Groep _groep2Donderdag { get; }
        public Groep _groep3Donderdag { get; }

        public SessieGroep _sessiegroep1 { get; }
        public SessieGroep _sessiegroep2 { get; }
        public SessieGroep _sessiegroep3 { get; }

        public SessieGroep _sessiegroep1Donderdag { get; }
        public SessieGroep _sessiegroep2Donderdag { get; }
        public SessieGroep _sessiegroep3Donderdag { get; }


        private readonly Bob _bob;
        private readonly ICollection<BobActie> _bobActies;
        private readonly ICollection<BobOefening> _bobOefeningen;
        private readonly ICollection<Sessie> _bobSessie;

        public DummyApplicationDbContextFilterData()
        {
            _bobActies = new Collection<BobActie>();
            _bobActies.Add(new BobActie { BobNaam = "bobActie", LijstActiesNaam = "zoek aarde" });
            _bobActies.Add(new BobActie { BobNaam = "bobActie", LijstActiesNaam = "zoek lucht" });

            //_bobOefeningen

            _bob = new Bob { Naam = "bob" };

            //Groepen
            _groep1 = new Groep
            {
                Contactleer = true,
                Currentstate = null,
                CurrentstateId = null,
                Fout = 0,
                GroepPad = null,
                Groepstate = null,
                Id = 1,
                Klas = "2C1",
                Leerlingen = "Axel",
                Naam = "Groep1"
            };
            _groep1.Currentstate = new GroepStartState(_groep1);
            _groep2 = new Groep
            {
                Contactleer = true,
                Currentstate = null,
                CurrentstateId = null,
                Fout = 0,
                GroepPad = null,
                Groepstate = null,
                Id = 2,
                Klas = "2C1",
                Leerlingen = "Thibaut",
                Naam = "Groep2"
            };
            _groep2.Currentstate = new GroepStartState(_groep2);
            _groep3 = new Groep
            {
                Contactleer = true,
                Currentstate = null,
                CurrentstateId = null,
                Fout = 0,
                GroepPad = null,
                Groepstate = null,
                Id = 3,
                Klas = "2C1",
                Leerlingen = "Michiel",
                Naam = "Groep3"
            };
            _groep3.Currentstate = new GroepStartState(_groep3);
            _groep4 = new Groep
            {
                Contactleer = true,
                Currentstate = null,
                CurrentstateId = null,
                Fout = 0,
                GroepPad = null,
                Groepstate = null,
                Id = 4,
                Klas = "2C1",
                Leerlingen = "Michiel",
                Naam = "Groep4"
            };
            _groep4.Currentstate = new Groepgeblokkeerdstate(_groep4);
            _sessiegroep1 = new SessieGroep { Groepen = _groep1 };
            _sessiegroep2 = new SessieGroep { Groepen = _groep2 };
            _sessiegroep3 = new SessieGroep { Groepen = _groep3 };

            //Sessies
            _maandag = new Sessie
            {
                Naam = "maandag",
                Code = 9999,
                Contactleer = true,
                Startdatum = new DateTime(2018, 05, 25),
                BobNaam = "bob",
                SessieGroep = new List<SessieGroep> { _sessiegroep1, _sessiegroep2, _sessiegroep3 }
            };
            _dinsdag = new Sessie
            {
                Naam = "dinsdag",
                Code = 9999,
                Contactleer = true,
                Startdatum = new DateTime(),
                BobNaam = "bob",
                SessieGroep = new List<SessieGroep> { _sessiegroep1, _sessiegroep2, _sessiegroep3 }
            };
            _woensdag = new Sessie
            {
                Naam = "woensdag",
                Code = 9599,
                Contactleer = true,
                Startdatum = new DateTime(2018, 05, 4),
                BobNaam = "bob2",
                SessieGroep = new List<SessieGroep> { _sessiegroep1, _sessiegroep2, _sessiegroep3 }
            };


            // Sessie voor Activatie
            //Groepen
            _groep1Donderdag = new Groep
            {
                Contactleer = true,
                Currentstate = null,
                CurrentstateId = null,
                Fout = 0,
                GroepPad = null,
                Groepstate = null,
                Id = 1,
                Klas = "2C1",
                Leerlingen = "Axel",
                Naam = "Groep1"
            };
            _groep1Donderdag.Currentstate = new Groepkanspelenstate(_groep1Donderdag);
            _groep2Donderdag = new Groep
            {
                Contactleer = true,
                Currentstate = null,
                CurrentstateId = null,
                Fout = 0,
                GroepPad = null,
                Groepstate = null,
                Id = 2,
                Klas = "2C1",
                Leerlingen = "Thibaut",
                Naam = "Groep2"
            };
            _groep2Donderdag.Currentstate = new Groepfinishedstate(_groep2Donderdag);
            _groep3Donderdag = new Groep
            {
                Contactleer = true,
                Currentstate = null,
                CurrentstateId = null,
                Fout = 0,
                GroepPad = null,
                Groepstate = null,
                Id = 3,
                Klas = "2C1",
                Leerlingen = "Michiel",
                Naam = "Groep3"
            };
            _groep3Donderdag.Currentstate = new Groepspeelstate(_groep3Donderdag);

            _sessiegroep1Donderdag = new SessieGroep { Groepen = _groep1Donderdag };
            _sessiegroep2Donderdag = new SessieGroep { Groepen = _groep2Donderdag };
            _sessiegroep3Donderdag = new SessieGroep { Groepen = _groep3Donderdag };

            _donderdag = new Sessie
            {
                Naam = "donderdag",
                Code = 9599,
                Contactleer = true,
                Startdatum = new DateTime(2018, 05, 4),
                BobNaam = "bob2",
                SessieGroep =
                    new List<SessieGroep> { _sessiegroep1Donderdag, _sessiegroep2Donderdag, _sessiegroep3Donderdag }
            };
        }

        private DateTime getDateBeforeToday()
        {
            return DateTime.Now.AddDays(-2);
        }

        private DateTime getDateAfterToday()
        {
            return new DateTime().AddDays(4);
        }

        public IEnumerable<Sessie> Sessies => new List<Sessie> { _maandag, _dinsdag, _woensdag };
    }
}