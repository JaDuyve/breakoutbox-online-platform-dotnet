using System;

namespace breakoutbox.Models.Domain
{
    public class Pad
    {
        #region Properties

        public int PadId { get; set; }
        public bool ContactLeer { get; set; }
        public string Antwoord { get; set; }
        public Oefening Oefening { get; set; }
        public Groepsbewerking Groepsbewerking { get; set; }
        public Toegangscode Toegangscode { get; set; }

        #endregion

        #region Constructors

        public Pad(bool contactLeer, string antwoord, Oefening oefening, Groepsbewerking groepsbewerking, Toegangscode toegangscode)
        {
            ContactLeer = contactLeer;
            Antwoord = antwoord;
            Oefening = oefening;
            Groepsbewerking = groepsbewerking;
            Toegangscode = toegangscode;
        }

        #endregion
    }
}