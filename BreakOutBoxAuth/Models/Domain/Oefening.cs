using System.Collections.Generic;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Oefening
    {
        public Oefening()
        {
            BobOefening = new HashSet<BobOefening>();
            OefeningDoelstellingscode = new HashSet<OefeningDoelstellingscode>();
            OefeningGroepsbewerking = new HashSet<OefeningGroepsbewerking>();
            Pad = new HashSet<Pad>();
        }

        [JsonProperty] public string Naam { get; set; }
        [JsonProperty] public string Antwoord { get; set; }
        [JsonProperty] public string Feedback { get; set; }
        [JsonProperty] public string Opgave { get; set; }
        [JsonProperty] public int Tijdslimiet { get; set; }
        [JsonProperty] public string VakNaam { get; set; }
        [JsonProperty] public Vak VakNaamNavigation { get; set; }
        public ICollection<BobOefening> BobOefening { get; set; }
        public ICollection<OefeningDoelstellingscode> OefeningDoelstellingscode { get; set; }
        public ICollection<OefeningGroepsbewerking> OefeningGroepsbewerking { get; set; }
        public ICollection<Pad> Pad { get; set; }
    }
}