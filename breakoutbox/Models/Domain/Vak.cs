using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace breakoutbox.Models.Domain
{
    public class Vak
    {
        public string Naam { get; set; }
        public string Kleur { get; set; }

        public Vak(string naam, string kleur)
        {
            Naam = naam;
            Kleur = kleur;
        }
    }
}
