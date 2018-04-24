using System;
using System.Collections.Generic;

namespace breakoutbox.Models
{
    public partial class SessieGroep
    {
        public SessieGroep()
        {
                
        }
        public string SessieNaam { get; set; }
        public decimal GroepenId { get; set; }

        public Groep Groepen { get; set; }
        public Sessie SessieNaamNavigation { get; set; }
    }
}
