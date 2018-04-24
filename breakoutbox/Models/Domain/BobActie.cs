using System;
using System.Collections.Generic;

namespace breakoutbox.Models
{
    public  class BobActie
    {
        public string BobNaam { get; set; }
        public string LijstActiesNaam { get; set; }

        public Bob BobNaamNavigation { get; set; }
        public Actie LijstActiesNaamNavigation { get; set; }

        public BobActie(string bobNaam, string lijstActiesNaam)
        {
            BobNaam = bobNaam;
            LijstActiesNaam = lijstActiesNaam;
        }
    }
}
