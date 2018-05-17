using System.Collections.Generic;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Toegangscode
    {
        public Toegangscode()
        {
            Pad = new HashSet<Pad>();
        }

        [JsonProperty] public decimal Id { get; set; }
        [JsonProperty] public int Code { get; set; }

        public ICollection<Pad> Pad { get; set; }
    }
}