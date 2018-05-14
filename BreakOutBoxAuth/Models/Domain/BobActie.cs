namespace BreakOutBoxAuth.Models
{
    public class BobActie
    {
        public BobActie(string bobNaam, string lijstActiesNaam)
        {
            BobNaam = bobNaam;
            LijstActiesNaam = lijstActiesNaam;
        }

        public BobActie()
        {
        }

        public string BobNaam { get; set; }
        public string LijstActiesNaam { get; set; }

        public Bob BobNaamNavigation { get; set; }
        public Actie LijstActiesNaamNavigation { get; set; }
    }
}