using System;

namespace BreakOutBoxAuth.Models.Domain
{
    public class GroepStartState: Groepstate
    {
        public GroepStartState()
        {
            
        }

        public GroepStartState(Groep groep):base(groep)
        {
            
        }
        
        public override void Finish()
        {
            throw new NotImplementedException();
        }

        public override void Blok()
        {
            throw new NotImplementedException();
        }

        public override void Spelen()
        {
            throw new NotImplementedException();
        }

        public override void KanSpelen()
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override void GekozenEnVergrendeld()
        {
            Groep.ToState(new Groepgekozenstate(Groep));
        }

        public override string GetStatus()
        {
            return "Starten";
        }

        public override Type GetClassType()
        {
            return GetType();
        }
    }
}