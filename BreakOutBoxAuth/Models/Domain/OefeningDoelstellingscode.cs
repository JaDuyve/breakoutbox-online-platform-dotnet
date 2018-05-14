namespace breakoutbox.Models
{
    public class OefeningDoelstellingscode
    {
        public string OefeningNaam { get; set; }
        public string DoelstellingscodesCode { get; set; }

        public Doelstellingscode DoelstellingscodesCodeNavigation { get; set; }
        public Oefening OefeningNaamNavigation { get; set; }
    }
}