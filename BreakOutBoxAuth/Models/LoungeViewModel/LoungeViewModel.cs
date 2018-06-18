using System;

namespace BreakOutBoxAuth.Models.LoungeViewModel
{
    public class LoungeViewModel
    {
        public LoungeViewModel(Groep groep, String sessieNaam)
        {
            Groep = groep;
            SessieNaam = sessieNaam;
        }

        public LoungeViewModel()
        {
            
        }

       
        public Groep Groep { get; set; }
        
        public string SessieNaam { get; set; }
    }
}