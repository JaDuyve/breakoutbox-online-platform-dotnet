using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.Domain;

namespace breakoutbox.Tests.Data
{
    public class DummyApplicationDbContext
    {
        public  Sessie _maandag { get; }
        public  Sessie _dinsdag { get; }
        public  Sessie _woensdag { get; }

        public GroepPad _groepPad1 { get; }
        public GroepPad _groepPad2 { get; }
        public GroepPad _groepPad3 { get; }
        
        private readonly Bob _bob;
        public Groep Groep { get; }
        public Groep GroepGemaaktVergrendeld { get; }
        public Groep GroepKanSpelen { get; }
        public Groep GroepBlok { get; }
        private readonly ICollection<BobActie> _bobActies;
        private readonly ICollection<BobOefening> _bobOefeningen;
        private readonly ICollection<Sessie> _bobSessie;
        private readonly ICollection<Groep> _groeps;

        public DummyApplicationDbContext()
        {
            _bobActies = new Collection<BobActie>();
            _bobActies.Add(new BobActie{BobNaam = "bobActie", LijstActiesNaam = "zoek aarde"});
            _bobActies.Add(new BobActie{BobNaam = "bobActie", LijstActiesNaam = "zoek lucht"});
            
            //_bobOefeningen
            
            _bob = new Bob { Naam = "bob"};
            _maandag = new Sessie {Naam = "maandag", Code = 9999, Contactleer = true, Startdatum = new DateTime(2018, 05, 25), BobNaam = "bob" };
            _dinsdag = new Sessie {Naam = "dinsdag", Code = 9999, Contactleer = true, Startdatum = new DateTime(), BobNaam = "bob" };
            _woensdag = new Sessie {Naam = "woensdag", Code = 9599, Contactleer = true, Startdatum = new DateTime(2018, 05, 04), BobNaam = "bob2" };
            
//            _groeps = new Collection<Groep>();
//            _groep1 = new Groep {Contactleer = false, Currentstate = null, CurrentstateId = 1, 3,null, }

            //Groep
            _pad1 = new Pad
            {
                Id = 1,
                Antwoord = "5",
                Contactleer = true,
                ActieNaam = "zoek doos",
                GroepsbewerkingNaam = "optellen",
                OefeningNaam = "oefening 1",
                ToegangscodeId = 8,
                ActieNaamNavigation = new Actie {Naam = "zoek doos", Opgave = "zoek doos"},
                Toegangscode = new Toegangscode{Code = 555},
            };
            _pad2 = new Pad
            {
                Id = 2,
                Antwoord = "5",
                Contactleer = true,
                ActieNaam = "zoek doos",
                GroepsbewerkingNaam = "optellen",
                OefeningNaam = "oefening 1",
                ToegangscodeId = 8,
                ActieNaamNavigation = new Actie {Naam = "zoek doos", Opgave = "zoek doos"}
            };
            _pad3 = new Pad
            {
                Id = 3,
                Antwoord = "5",
                Contactleer = true,
                ActieNaam = "zoek doos",
                GroepsbewerkingNaam = "optellen",
                OefeningNaam = "oefening 1",
                ToegangscodeId = 8,
                ActieNaamNavigation = new Actie {Naam = "zoek doos", Opgave = "zoek doos"}
            };

            _groepPad1 = new GroepPad {GroepId = 8, PadenId = 1, PadenKey = 1, Paden = _pad1};
            _groepPad2 = new GroepPad {GroepId = 9, PadenId = 1, PadenKey = 2, Paden = _pad2}; 
            _groepPad3 = new GroepPad {GroepId = 10, PadenId = 1, PadenKey = 3, Paden = _pad3}; 

            Groep = new Groep
            {
                Id = 8,
                Naam = "Groep",
                Klas = "2C",
                Contactleer = true,
                Fout = 3,
                GroepPad = new List<GroepPad>{_groepPad1, _groepPad2, _groepPad3},
                Progress = 1
            };
            //Groepen
            GroepGemaaktVergrendeld = new Groep
            {
                Contactleer = true,
                Currentstate = null,
                CurrentstateId = null,
                Fout = 0,
                GroepPad = null,
                Groepstate = null,
                Id = 1,
                Klas = "2C1",
                Leerlingen = "AxelChippie",
                Naam = "Groep1"
            };
            GroepGemaaktVergrendeld.Currentstate = new Groepgekozenstate(GroepGemaaktVergrendeld);
            GroepBlok = new Groep
            {
                Contactleer = true,
                Currentstate = null,
                CurrentstateId = null,
                Fout = 3,
                GroepPad = null,
                Groepstate = null,
                Id = 2,
                Klas = "2C1",
                Leerlingen = "AxelHippie",
                Naam = "slecht"
            };
            GroepBlok.Currentstate = new Groepgeblokkeerdstate(GroepBlok);
            GroepKanSpelen = new Groep
            {
                Contactleer = true,
                Currentstate = null,
                CurrentstateId = null,
                Fout = 1,
                GroepPad = new List<GroepPad> { new GroepPad
                        { GroepId = 8, PadenId = 1, PadenKey = 1, Paden = new Pad
                                { Id = 1, Antwoord = "5", Contactleer = true, ActieNaam = "zoek doos", GroepsbewerkingNaam = "optellen", OefeningNaam = "oefening 1", ToegangscodeId = 8, ActieNaamNavigation = new Actie
                                            { Naam = "zoek doos", Opgave = "zoek doos" }, OefeningNaamNavigation = new Oefening {
                                            Naam = "Blabla", Antwoord = "blabla", Feedback="blabla", Opgave = "blabla", Tijdslimiet = 7, VakNaam = "vak", OefeningGroepsbewerking = new List<OefeningGroepsbewerking>{
                                               new OefeningGroepsbewerking{ LijstGroepsbewerkingenNaamNavigation= new Groepsbewerking {
                                            Naam = "blabla", Bewerking = "+", Opgave = "ja", Waarde = "Lange test"} } } } } } },
                Groepstate = null,
                Id = 3,
                Klas = "2C1",
                Leerlingen = "AxelHippie",
                Naam = "slecht",
                Progress = 1
            };
            GroepKanSpelen.Currentstate = new Groepkanspelenstate(GroepKanSpelen);
        }


        private DateTime getDateBeforeToday()
        {
            return new DateTime().AddDays(-2);
        }

        private DateTime getDateAfterToday()
        {
            return new DateTime().AddDays(4);
        }

        public IEnumerable<Sessie> Sessies => new List<Sessie> { _maandag, _dinsdag, _woensdag };

    }
}