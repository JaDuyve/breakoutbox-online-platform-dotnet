using System;
using BreakOutBoxAuth.Models.Domain;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Groepgekozenstate: Groepstate
    {

        public Groepgekozenstate(Groep groep):base(groep)
        {
           
        }

        public Groepgekozenstate()
        {
            
        }

        
        public override void KanSpelen()
        {
            Groep.ToState(new Groepkanspelenstate(Groep));
        }

        

        public override Type GetClassType()
        {
            return GetType();
        }

        public override string GetStatus()
        {
            return "Gekozen & vergrendeld";
        }

        public override State getStateEnum()
        {
            return State.GEKOZENVERGRENDELD;
        }

        
    }
}