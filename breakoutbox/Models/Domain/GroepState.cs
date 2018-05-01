using System.Collections.Generic;

namespace breakoutbox.Models
{
    public abstract class Groepstate
    {
        
        
        protected Groepstate()
        {
            
        }

        public Groepstate(Groep groep)
        {
           Groep = groep;
            
            
        }

        

        public Groep Groep { get; set; }
        public decimal? GroepId { get; set; }

        public abstract void Finish();
        

        public abstract void Blok();
        

        public abstract void Spelen();


        public abstract void KanSpelen();

        public abstract void GekozenEnVergrendeld();
        
    }
}