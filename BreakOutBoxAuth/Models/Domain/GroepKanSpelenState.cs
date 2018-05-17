using System;
using BreakOutBoxAuth.Models.Domain;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Groepkanspelenstate: Groepstate
    {


        public Groepkanspelenstate(Groep groep):base(groep)
        {
            
        }

        public Groepkanspelenstate()
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
            return "kan Beginnen Spelen";
        }

        public override State getStateEnum()
        {
            return State.KANSPELEN;
        }

        
    }
}