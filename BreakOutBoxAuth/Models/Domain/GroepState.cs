using System;
using System.Collections.Generic;

namespace BreakOutBoxAuth.Models
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

        
        public int Id { get; set; }
        public Groep Groep { get; set; }
        public decimal? GroepId { get; set; }

        public abstract void Finish();
        

        public abstract void Blok();
        

        public abstract void Spelen();


        public abstract void KanSpelen();

        public abstract void Start();
        
        public abstract void GekozenEnVergrendeld();

        public abstract Type GetClassType();

        public abstract string GetStatus();
    }
}