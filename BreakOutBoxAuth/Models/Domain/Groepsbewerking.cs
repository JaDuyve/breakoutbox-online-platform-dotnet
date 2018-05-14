using System.Collections.Generic;

namespace breakoutbox.Models
{
    public class Groepsbewerking
    {
        public Groepsbewerking()
        {
            OefeningGroepsbewerking = new HashSet<OefeningGroepsbewerking>();
            Pad = new HashSet<Pad>();
        }

        public string Naam { get; set; }
        public string Bewerking { get; set; }
        public string Opgave { get; set; }
        public string Waarde { get; set; }

        public ICollection<OefeningGroepsbewerking> OefeningGroepsbewerking { get; set; }
        public ICollection<Pad> Pad { get; set; }
    }
}