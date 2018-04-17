namespace breakoutbox.Models.Domain
{
    public class Toegangscode
    {
        #region Properties

        public int ToegangscodeId { get; set; }
        public string Code { get; set; }
        
        #endregion

        #region Constructors

        public Toegangscode(string code)
        {
            Code = code;
        }

        #endregion
    }
}