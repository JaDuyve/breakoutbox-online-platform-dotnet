using System;
using System.Collections.Generic;

namespace breakoutbox.Models
{
    public partial class Groep
    {
        public Groep()
        {
            GroepPad = new HashSet<GroepPad>();
            Groepstate = new HashSet<Groepstate>();
            SessieGroep = new HashSet<SessieGroep>();
        }

        public decimal Id { get; set; }
        public bool? Contactleer { get; set; }
        public string Klas { get; set; }
        public string Naam { get; set; }
        public int? Progress { get; set; }
        public decimal? CurrentstateId { get; set; }
        public Groepstate Currentstate { get; set; }
        public ICollection<GroepPad> GroepPad { get; set; }
        public ICollection<Groepstate> Groepstate { get; set; }
        public ICollection<SessieGroep> SessieGroep { get; set; }
    }
}
