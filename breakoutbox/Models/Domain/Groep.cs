using System;
using System.Collections.Generic;

namespace breakoutbox.Models
{
    public partial class Groep
    {
        public decimal Id { get; set; }
        public bool Contactleer { get; set; }
        public string Klas { get; set; }
        public string Naam { get; set; }

        public ICollection<GroepPad> GroepPad { get; set; }
        public ICollection<SessieGroep> SessieGroep { get; set; }
        
        public Groep(string klas)
        {
            this.Klas = klas;
            GroepPad = new HashSet<GroepPad>();
            SessieGroep = new HashSet<SessieGroep>();
        }

        
    }
}
