using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Sessie
    {
        public Sessie()
        {
            SessieGroep = new Collection<SessieGroep>();
        }

        [JsonProperty] public string Naam { get; set; }
        public int Code { get; set; }
        public bool Contactleer { get; set; }
        public DateTime Startdatum { get; set; }
        public string BobNaam { get; set; }
        public bool HasEnded { get; set; }
        public Bob BobNaamNavigation { get; set; }
        public ICollection<SessieGroep> SessieGroep { get; set; }
    }
}