using System;
using System.Collections.Generic;

namespace breakoutbox.Models
{
    public partial class OefeningGroepsbewerking
    {
        public string OefeningNaam { get; set; }
        public string LijstGroepsbewerkingenNaam { get; set; }

        public Groepsbewerking LijstGroepsbewerkingenNaamNavigation { get; set; }
        public Oefening OefeningNaamNavigation { get; set; }

        public OefeningGroepsbewerking()
        {
            
        }
    }
}
