namespace breakoutbox.Models
{
    public class SessieGroep
    {
        public string SessieNaam { get; set; }
        public decimal GroepenId { get; set; }

        public Groep Groepen { get; set; }
        public Sessie SessieNaamNavigation { get; set; }
    }
}