using System.Collections.Generic;

namespace breakoutbox.Models
{
    public class Oefening
    {
        public Oefening()
        {
            BobOefening = new HashSet<BobOefening>();
            OefeningDoelstellingscode = new HashSet<OefeningDoelstellingscode>();
            OefeningGroepsbewerking = new HashSet<OefeningGroepsbewerking>();
            Pad = new HashSet<Pad>();
        }

        public string Naam { get; set; }
        public string Antwoord { get; set; }
        public string Feedback { get; set; }
        public string Opgave { get; set; }
        public int? Tijdslimiet { get; set; }
        public string VakNaam { get; set; }

        public Vak VakNaamNavigation { get; set; }
        public ICollection<BobOefening> BobOefening { get; set; }
        public ICollection<OefeningDoelstellingscode> OefeningDoelstellingscode { get; set; }
        public ICollection<OefeningGroepsbewerking> OefeningGroepsbewerking { get; set; }
        public ICollection<Pad> Pad { get; set; }
    }
}