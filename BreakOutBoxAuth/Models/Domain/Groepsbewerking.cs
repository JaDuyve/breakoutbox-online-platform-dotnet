using System.Collections.Generic;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Groepsbewerking
    {
        public Groepsbewerking()
        {
            OefeningGroepsbewerking = new HashSet<OefeningGroepsbewerking>();
            Pad = new HashSet<Pad>();
        }

        [JsonProperty] public string Naam { get; set; }
        [JsonProperty] public string Bewerking { get; set; }
        [JsonProperty] public string Opgave { get; set; }
        [JsonProperty] public string Waarde { get; set; }

        public ICollection<OefeningGroepsbewerking> OefeningGroepsbewerking { get; set; }
        public ICollection<Pad> Pad { get; set; }
    }
}