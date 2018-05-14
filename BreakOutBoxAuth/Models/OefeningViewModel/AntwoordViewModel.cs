namespace BreakOutBoxAuth.Models.OefeningViewModel
{
    public class AntwoordViewModel
    {
        public AntwoordViewModel(Pad pad, Groep groep)
        {
            Pad = pad;
            Groep = groep;
        }

        public AntwoordViewModel()
        {
        }

        public string Antwoord { get; set; }
        public Pad Pad { get; set; }
        public Groep Groep { get; set; }
    }
}