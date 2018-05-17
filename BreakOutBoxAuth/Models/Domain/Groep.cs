using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BreakOutBoxAuth.Models.Domain;
using Newtonsoft.Json;
using SQLitePCL;

namespace BreakOutBoxAuth.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Groep
    {
        public Groep()
        {
            GroepPad = new HashSet<GroepPad>();
            Groepstate = new HashSet<Groepstate>();
            SessieGroep = new HashSet<SessieGroep>();

//            ToState(new Groepgekozenstate(this));
        }

        [JsonProperty] public decimal Id { get; set; }
        [JsonProperty] public bool Contactleer { get; set; }
        [JsonProperty] public string Klas { get; set; }
        [JsonProperty] public string Naam { get; set; }
        [JsonProperty] public int Progress { get; set; }
        [JsonProperty] public Groepstate Currentstate { get; set; }
        [JsonProperty] public ICollection<GroepPad> GroepPad { get; set; }
         public ICollection<Groepstate> Groepstate { get; set; }
        public ICollection<SessieGroep> SessieGroep { get; set; }
        [JsonProperty] public string Leerlingen { get; set; }
        [JsonProperty] public int? CurrentstateId { get; set; }
        [JsonProperty] public int Fout { get; set; }


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
            ICollection<string> leerling = Leerlingen.Substring(0, Leerlingen.Length - 2).Split(",");
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
            ToState(new GroepStartState(this));
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

        public int GetProgress100()
        {
            Double progress = Convert.ToDouble(Progress);
            Double count = Convert.ToDouble(GroepPad.Count);

            return Convert.ToInt32(Math.Floor((progress / count) * 100));
        }
    }
}