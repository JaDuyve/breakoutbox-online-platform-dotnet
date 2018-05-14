using System.Collections.Generic;

namespace BreakOutBoxAuth.Models
{
    public class Vak
    {
        public Vak()
        {
            Oefening = new HashSet<Oefening>();
        }


        public string Naam { get; set; }
        public string Kleur { get; set; }

        public ICollection<Oefening> Oefening { get; set; }
    }
}