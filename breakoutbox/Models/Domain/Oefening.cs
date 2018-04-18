using System.Collections.Generic;

namespace breakoutbox.Models.Domain
{
    public class Oefening
    {
        public string Naam { get; set; }      
        public string Opgave { get; set; }    
        public string Feedback { get; set; }   
        public string Antwoord { get; set; }  
        public int Tijdslimiet { get; set; }  

        public Vak Vak { get; set; }

        public Oefening(string naam, string opgave, string feedback, string antwoord, int tijdslimiet, Vak vak)
        {
            Naam = naam;
            Opgave = opgave;
            Feedback = feedback;
            Antwoord = antwoord;
            Tijdslimiet = tijdslimiet;
            Vak = vak;
        }
    }
}