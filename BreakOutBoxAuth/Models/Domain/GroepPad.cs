namespace breakoutbox.Models
{
    public class GroepPad
    {
        public decimal GroepId { get; set; }
        public decimal PadenId { get; set; }
        public int PadenKey { get; set; }

        public Groep Groep { get; set; }
        public Pad Paden { get; set; }
    }
}