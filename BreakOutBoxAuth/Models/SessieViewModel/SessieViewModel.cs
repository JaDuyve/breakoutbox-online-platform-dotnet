using System.Collections.Generic;

namespace BreakOutBoxAuth.Models.SessieViewModel
{
    public class SessieViewModel
    {
        public SessieViewModel(IEnumerable<Sessie> sessies)
        {
            Sessies = sessies;
        }

        public SessieViewModel(int code)
        {
            Code = code;
        }

        public SessieViewModel()
        {
        }

        public int Code { get; set; }
        public IEnumerable<Sessie> Sessies { get; set; }
    }
}