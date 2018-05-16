using System;
using BreakOutBoxAuth.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BreakOutBoxAuth.Models
{
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

        public override State getStateEnum()
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