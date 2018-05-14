using System.Collections.Generic;

namespace BreakOutBoxAuth.Models
{
    public class Pad
    {
        public Pad()
        {
            GroepPad = new HashSet<GroepPad>();
        }

        public decimal Id { get; set; }
        public string Antwoord { get; set; }
        public bool? Contactleer { get; set; }
        public string ActieNaam { get; set; }
        public string GroepsbewerkingNaam { get; set; }
        public string OefeningNaam { get; set; }
        public decimal? ToegangscodeId { get; set; }

        public Actie ActieNaamNavigation { get; set; }
        public Groepsbewerking GroepsbewerkingNaamNavigation { get; set; }
        public Oefening OefeningNaamNavigation { get; set; }
        public Toegangscode Toegangscode { get; set; }
        public ICollection<GroepPad> GroepPad { get; set; }
    }
}