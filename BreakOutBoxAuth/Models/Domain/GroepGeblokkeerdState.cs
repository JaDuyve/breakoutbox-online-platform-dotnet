using System;
using BreakOutBoxAuth.Models.Domain;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Models
{
    [JsonObject(MemberSerialization.OptIn)]
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