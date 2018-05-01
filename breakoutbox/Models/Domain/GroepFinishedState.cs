using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace breakoutbox.Models
{
    public class Groepfinishedstate: Groepstate
    {
        
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
            throw new System.NotImplementedException();
        }

        public override void KanSpelen()
        {
            throw new System.NotImplementedException();
        }

        public override void GekozenEnVergrendeld()
        {
            throw new System.NotImplementedException();
        }
        
        public decimal IdF { get; set; }

        public Groepfinishedstate(Groep groep):base(groep)
        {
            
        }
    }
}