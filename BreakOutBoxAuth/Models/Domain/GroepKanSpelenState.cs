using System;
using BreakOutBoxAuth.Models.Domain;

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

        public override void Start()
        {
            throw new NotImplementedException();
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

        public override void GekozenEnVergrendeld()
        {
            throw new System.NotImplementedException();
        }
    }
}