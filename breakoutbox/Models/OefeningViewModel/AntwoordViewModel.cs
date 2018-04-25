namespace breakoutbox.Models.OefeningViewModel
{
    public class AntwoordViewModel
    {
        public string Antwoord { get; set; }
        public Pad Pad { get; set; }
        public Groep Groep { get; set; }
        
        public AntwoordViewModel(Pad pad,  Groep groep)
        {
            Pad = pad;
            Groep = groep;
        }

        public AntwoordViewModel()
        {
            
        }
    }
    
    
}