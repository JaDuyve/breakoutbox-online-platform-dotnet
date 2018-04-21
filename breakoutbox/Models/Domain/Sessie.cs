using System;
using System.Collections.Generic;

namespace breakoutbox.Models.Domain
{
    public class Sessie
    {
        public string Naam { get; set; }
        public DateTime StartDatum { get; set; }
        public int Code { get; set; }
        public bool ContactLeer { get; set; }
        public IList<Groep> Groepen { get; set; }
        public Bob Bob { get; set; }

        public Sessie(string naam, DateTime startDatum, int code, bool contactLeer, List<Groep> groepen, Bob bob)
        {
            Naam = naam;
            StartDatum = startDatum;
            Code = code;
            ContactLeer = contactLeer;
            Groepen = groepen;
            Bob = bob;
        }

        protected Sessie()
        {
            
        }
    }
}