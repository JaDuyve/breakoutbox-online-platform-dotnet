using System;
using BreakOutBoxAuth.Models.Domain;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Groepspeelstate : Groepstate
    {
        public Groepspeelstate(Groep groep) : base(groep)
        {
        }

        public Groepspeelstate()
        {
        }

        public override void Finish()
        {
            Groep.ToState(new Groepfinishedstate(Groep));
        }

        public override void Blok()
        {
            Groep.ToState(new Groepgeblokkeerdstate(Groep));
        }


        public override Type GetClassType()
        {
            return GetType();
        }

        public override string GetStatus()
        {
            return "Spelen";
        }

        public override State GetStateEnum()
        {
            return State.SPELEN;
        }
    }
}