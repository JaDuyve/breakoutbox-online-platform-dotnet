namespace BreakOutBoxAuth.Models
{
    public class OefeningGroepsbewerking
    {
        public string OefeningNaam { get; set; }
        public string LijstGroepsbewerkingenNaam { get; set; }

        public Groepsbewerking LijstGroepsbewerkingenNaamNavigation { get; set; }
        public Oefening OefeningNaamNavigation { get; set; }
    }
}