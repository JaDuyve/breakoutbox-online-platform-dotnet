namespace breakoutbox.Models
{
    public class Groepgekozenstate: Groepstate
    {
        public decimal Id { get; set; }


        public Groepgekozenstate(Groep groep):base(groep)
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
            throw new System.NotImplementedException();
        }

        public override void KanSpelen()
        {
            Groep.ToState(new Groepkanspelenstate(Groep));
        }

        public override void GekozenEnVergrendeld()
        {
            throw new System.NotImplementedException();
        }
    }
}