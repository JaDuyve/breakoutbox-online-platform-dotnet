using System.Collections.Generic;

namespace breakoutbox.Models.Domain
{
    public class Bob
    {
        public string Naam { get; set; }
        public List<Oefening> LijstOefeningen { get; set; }
        public List<Actie> LijstActies { get; set; }

        public Bob(string naam, List<Oefening> lijstOefeningen, List<Actie> lijstActies)
        {
            Naam = naam;
            LijstOefeningen = lijstOefeningen;
            LijstActies = lijstActies;
        }
    }
}