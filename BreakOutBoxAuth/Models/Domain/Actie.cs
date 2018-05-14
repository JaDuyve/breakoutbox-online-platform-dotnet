using System.Collections.Generic;

namespace breakoutbox.Models
{
    public class Actie
    {
        public Actie()
        {
            BobActie = new HashSet<BobActie>();
            Pad = new HashSet<Pad>();
        }


        public string Naam { get; set; }
        public string Opgave { get; set; }

        public ICollection<BobActie> BobActie { get; set; }
        public ICollection<Pad> Pad { get; set; }
    }
}