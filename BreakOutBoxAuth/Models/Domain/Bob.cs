using System.Collections.Generic;

namespace BreakOutBoxAuth.Models
{
    public class Bob
    {
        public Bob()
        {
            BobActie = new HashSet<BobActie>();
            BobOefening = new HashSet<BobOefening>();
            Sessie = new HashSet<Sessie>();
        }

        public string Naam { get; set; }

        public ICollection<BobActie> BobActie { get; set; }
        public ICollection<BobOefening> BobOefening { get; set; }
        public ICollection<Sessie> Sessie { get; set; }
    }
}