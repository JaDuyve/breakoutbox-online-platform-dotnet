using System.Collections.Generic;
using breakoutbox.Models.Domain;

namespace breakoutbox.Models
{
    public class Groep
    {
        public Groep()
        {
            GroepPad = new HashSet<GroepPad>();
            Groepstate = new HashSet<Groepstate>();
            SessieGroep = new HashSet<SessieGroep>();
            
            ToState(new Groepgekozenstate(this));
        }

        public decimal Id { get; set; }
        public bool? Contactleer { get; set; }
        public string Klas { get; set; }
        public string Naam { get; set; }
        public int? Progress { get; set; }
        public Groepstate Currentstate { get; set; }
        public ICollection<GroepPad> GroepPad { get; set; }
        public ICollection<Groepstate> Groepstate { get; set; }
        public ICollection<SessieGroep> SessieGroep { get; set; }
        public string Leerlingen { get; set; } 
        public int CurrentstateId { get; set; }
        
        public void Blok()
        {
            Currentstate.Blok();
        }

        public void Spelen()
        {
            Currentstate.Spelen();
        }

        public void Finish()
        {
            Currentstate.Finish();
        }

        public void KanSpelen()
        {
            Currentstate.KanSpelen();
        }

        public void GekozenEnVergrendeld()
        {
            Currentstate.GekozenEnVergrendeld();
        }

        public void ToState(Groepstate state)
        {
            Currentstate = state;
        }
    }
}