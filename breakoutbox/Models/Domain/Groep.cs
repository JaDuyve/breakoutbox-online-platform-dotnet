using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            
//            ToState(new Groepgekozenstate(this));
        }

        public decimal Id { get; set; }
        public bool Contactleer { get; set; }
        public string Klas { get; set; }
        public string Naam { get; set; }
        public int Progress { get; set; }
        public Groepstate Currentstate { get; set; }
        public ICollection<GroepPad> GroepPad { get; set; }
        public ICollection<Groepstate> Groepstate { get; set; }
        public ICollection<SessieGroep> SessieGroep { get; set; }
        public string Leerlingen { get; set; } 
        public int? CurrentstateId { get; set; }
        public int Fout { get; set; }
        
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

        public ICollection<string> LijstLeerlingen()
        {
            ICollection<string> leerling = Leerlingen.Substring(0, Leerlingen.Length -3).Split(",");
            return leerling;
        }

        private IDictionary<int, GroepPad> ConvertGroepPaden()
        {
            IDictionary<int, GroepPad> paden = new Dictionary<int, GroepPad>();
            foreach (var pad in GroepPad)
            {
                paden.Add(pad.PadenKey, pad);
            }

            return paden;
        }

        public GroepPad getCurrentGroepPad(int key)
        {
            return ConvertGroepPaden()[key];
        }

        public void InitializeState()
        {
            ToState(new Groepgekozenstate(this));
        }

        public void VerhoogProgress()
        {
            Progress++;
        }

        public void VerhoogFout()
        {
            Fout++;
        }

        public void ResetFout()
        {
            Fout = 0;
        }
    }
}