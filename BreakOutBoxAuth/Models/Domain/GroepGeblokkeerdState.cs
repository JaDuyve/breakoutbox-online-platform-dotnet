using System;
using BreakOutBoxAuth.Models.Domain;

namespace BreakOutBoxAuth.Models
{
    public class Groepgeblokkeerdstate: Groepstate
    {


        public Groepgeblokkeerdstate(Groep groep):base(groep)
        {
            
        }

        public Groepgeblokkeerdstate()
        {
            
        }

        public override void Spelen()
        {
            
            Groep.ToState(new Groepspeelstate(Groep));
            
            
        }

        

        

        public override Type GetClassType()
        {
            return GetType();
        }

        public override string GetStatus()
        {
            return "Geblokkeerd";
        }

        public override State getStateEnum()
        {
            return State.BLOK;
        }

       
    }
}