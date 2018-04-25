namespace breakoutbox.Models.OefeningViewModel
{
    public class AntwoordViewModel
    {
        public string Antwoord { get; set; }
        public Oefening Oefening { get; set; }
        public string Groepsnaam { get; set; }
        public AntwoordViewModel(Oefening oefening, string groepsnaam)
        {
            Oefening = oefening;
            Groepsnaam = groepsnaam;
        }
    }
    
    
}