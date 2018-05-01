namespace breakoutbox.Models
{
    public class Groepgeblokkeerdstate: Groepstate
    {


        public Groepgeblokkeerdstate(Groep groep):base(groep)
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

        public override void GekozenEnVergrendeld()
        {
            throw new System.NotImplementedException();
        }
    }
}