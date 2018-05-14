namespace BreakOutBoxAuth.Models
{
    public class BobOefening
    {
        public string BobNaam { get; set; }
        public string LijstOefeningenNaam { get; set; }

        public Bob BobNaamNavigation { get; set; }
        public Oefening LijstOefeningenNaamNavigation { get; set; }
    }
}