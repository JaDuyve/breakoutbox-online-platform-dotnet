using System;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Models.Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GroepStartState : Groepstate
    {
        public GroepStartState()
        {
        }

        public GroepStartState(Groep groep) : base(groep)
        {
        }


        public override void KanSpelen()
        {
            Groep.ToState(new Groepkanspelenstate(Groep));
        }


        public override void GekozenEnVergrendeld()
        {
            Groep.ToState(new Groepgekozenstate(Groep));
        }

        public override string GetStatus()
        {
            return "Starten";
        }

        public override State GetStateEnum()
        {
            return State.START;
        }

        public override Type GetClassType()
        {
            return GetType();
        }
    }
}