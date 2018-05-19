using System;
using BreakOutBoxAuth.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Groepfinishedstate: Groepstate
    {
        
        

        public override Type GetClassType()
        {
            return GetType();
        }

        public override string GetStatus()
        {
            return "Uitgespeeld";
        }

        public override State GetStateEnum()
        {
            return State.FINISH;
        }


        public Groepfinishedstate(Groep groep):base(groep)
        {
            
        }

        public Groepfinishedstate()
        {
            
        }
    }
}