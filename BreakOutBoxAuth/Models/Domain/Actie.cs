using System.Collections.Generic;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Actie
    {
        public Actie()
        {
            BobActie = new HashSet<BobActie>();
            Pad = new HashSet<Pad>();
        }

        [JsonProperty] public string Naam { get; set; }
        [JsonProperty] public string Opgave { get; set; }

        public ICollection<BobActie> BobActie { get; set; }
        public ICollection<Pad> Pad { get; set; }
    }
}