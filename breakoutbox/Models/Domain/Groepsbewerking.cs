namespace breakoutbox.Models.Domain
{
    public class Groepsbewerking
    {
        #region Properties

        public string Naam { get; set; }
        public string Opgave { get; set; }
        public string Waarde { get; set; }
        

        #endregion

        #region Constructors

        public Groepsbewerking(string opgave, string naam, string waarde)
        {
            Naam = naam;
            Opgave = opgave;
            Waarde = waarde;
        }

        #endregion
    }
}