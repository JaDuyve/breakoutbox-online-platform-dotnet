using System;

namespace breakoutbox.Models
{
    public class Groepkanspelenstate: Groepstate
    {


        public Groepkanspelenstate(Groep groep):base(groep)
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

        public override void GekozenEnVergrendeld()
        {
            throw new System.NotImplementedException();
        }
    }
}