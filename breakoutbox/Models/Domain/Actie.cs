using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace breakoutbox.Models.Domain
{
    public class Actie
    {
        public string Naam { get; set; }
        public string Opgave { get; set; }

        public Actie(string naam, string opgave)
        {
            Naam = naam;
            Opgave = opgave;
        }
    }
}
