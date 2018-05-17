using Newtonsoft.Json;

namespace BreakOutBoxAuth.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GroepPad
    {
        [JsonProperty] public decimal GroepId { get; set; }
        [JsonProperty] public decimal PadenId { get; set; }
        [JsonProperty] public int PadenKey { get; set; }

        public Groep Groep { get; set; }
        [JsonProperty] public Pad Paden { get; set; }
    }
}