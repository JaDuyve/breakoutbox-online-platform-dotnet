using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace breakoutbox.Models.SessieViewModel
{
    public class SessieViewModel
    {
        public int Code { get; set; }
        public IEnumerable<Sessie> Sessies { get; set; }
        public SessieViewModel( IEnumerable<Sessie> sessies)
        {
            Sessies = sessies;
        }
        public SessieViewModel(int code)
        {
            Code = code;
        }
    }
}
