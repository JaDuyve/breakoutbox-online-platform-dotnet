using System;

namespace BreakOutBoxAuth.Models.LoungeViewModel
{
    public class LoungeViewModel
    {
        public LoungeViewModel(Groep groep)
        {
            Groep = groep;
        }

        public LoungeViewModel()
        {
            
        }

       
        public Groep Groep { get; set; }
        
    }
}