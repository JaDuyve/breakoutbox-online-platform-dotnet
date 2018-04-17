using System.Collections.Generic;

namespace breakoutbox.Models.Domain
{
    public class Groep
    {
        public long ID { get; set; }
        public string Naam { get; set; }
        public string Klas { get; set; }
        public bool Contactleer { get; set; }
        public List<string> Leerlingen { get; set; }
        public Dictionary<int, Pad> Paden { get; set; }

        public Groep(string naam, string klas, bool contactleer, List<string> leerlingen, Dictionary<int, Pad> paden)
        {
            Naam = naam;
            Klas = klas;
            Contactleer = contactleer;
            Leerlingen = leerlingen;
            Paden = paden;
        }

        public bool isContactleer()
        {
            return Contactleer;
        }
    }
}