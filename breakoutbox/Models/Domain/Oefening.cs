using System.Collections.Generic;

namespace breakoutbox.Models.Domain
{
    public class Oefening
    {
        public int OefeningId { get; set; }
        public string Naam { get; set; }      
        public string Opgave { get; set; }    
        public string Feedback { get; set; }   
        public string Antwoord { get; set; }  
        public int Tijdslimiet { get; set; }  

        public Vak Vak { get; set; }

        public Oefening(int id, string naam, string opgave, string feedback, string antwoord, int tijdslimiet, Vak vak)
        {
            OefeningId = id;
            Naam = naam;
            Opgave = opgave;
            Feedback = feedback;
            Antwoord = antwoord;
            Tijdslimiet = tijdslimiet;
            Vak = vak;
        }
    }
}