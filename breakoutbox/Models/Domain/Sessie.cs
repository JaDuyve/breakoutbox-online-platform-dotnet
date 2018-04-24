using System;
using System.Collections.Generic;

namespace breakoutbox.Models
{
    public partial class Sessie
    {
        public Sessie()
        {
            SessieGroep = new HashSet<SessieGroep>();
        }

        public string Naam { get; set; }
        public int? Code { get; set; }
        public bool? Contactleer { get; set; }
        public DateTime? Startdatum { get; set; }
        public string BobNaam { get; set; }

        public Bob BobNaamNavigation { get; set; }
        public ICollection<SessieGroep> SessieGroep { get; set; }
    }
}
