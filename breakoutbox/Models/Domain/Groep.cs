using System;
using System.Collections.Generic;

namespace breakoutbox.Models.Domain
{
    public class Groep
    {
        public Decimal Id { get; set; }
        public string Naam { get; set; }
        public string Klas { get; set; }
        public bool Contactleer { get; set; }
//        public ICollection<String> Leerlingen { get; set; }
        public IDictionary<int, Pad> Paden { get; set; }
        
        protected Groep()
        {
            
        }
        
        public Groep(string naam, string klas, bool contactleer/*, List<string> leerlingen*/, Dictionary<int, Pad> paden)
        {
            Naam = naam;
            Klas = klas;
            Contactleer = contactleer;
//            Leerlingen = leerlingen;
            Paden = paden;
        }

        public bool isContactleer()
        {
            return Contactleer;
        }
    }
}