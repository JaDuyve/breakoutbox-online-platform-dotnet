using System;

namespace BreakOutBoxAuth.Models
{
    public class Groepkanspelenstate: Groepstate
    {


        public Groepkanspelenstate(Groep groep):base(groep)
        {
            
        }

        public Groepkanspelenstate()
        {
            
        }

        public override void Finish()
        {
            throw new System.NotImplementedException();
        }

        public override void Blok()
        {
            throw new System.NotImplementedException();
        }

        public override void Spelen()
        {
            Groep.ToState(new Groepspeelstate(Groep));
        }

        public override void KanSpelen()
        {
            throw new System.NotImplementedException();
        }
        
        public override Type GetClassType()
        {
            return GetType();
        }

        public override string GetStatus()
        {
            return "kan Beginnen Spelen";
        }

        public override void GekozenEnVergrendeld()
        {
            throw new System.NotImplementedException();
        }
    }
}