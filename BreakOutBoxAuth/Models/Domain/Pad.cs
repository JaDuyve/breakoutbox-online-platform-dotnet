using System.Collections.Generic;
using System.Data.Common;
using BreakOutBoxAuth.Models.OefeningViewModel;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Pad
    {
        public Pad()
        {
            GroepPad = new HashSet<GroepPad>();
        }

        [JsonProperty] public decimal Id { get; set; }
        [JsonProperty] public string Antwoord { get; set; }
        [JsonProperty] public bool? Contactleer { get; set; }
        [JsonProperty] public string ActieNaam { get; set; }
        [JsonProperty] public string GroepsbewerkingNaam { get; set; }
        [JsonProperty] public string OefeningNaam { get; set; }
        [JsonProperty] public decimal? ToegangscodeId { get; set; }
        [JsonProperty] public Actie ActieNaamNavigation { get; set; }
        [JsonProperty] public Groepsbewerking GroepsbewerkingNaamNavigation { get; set; }
        [JsonProperty] public Oefening OefeningNaamNavigation { get; set; }
        [JsonProperty] public Toegangscode Toegangscode { get; set; }


        public ICollection<GroepPad> GroepPad { get; set; }
    }
} 

