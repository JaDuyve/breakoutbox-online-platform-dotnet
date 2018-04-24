using System;
using System.Collections.Generic;

namespace breakoutbox.Models
{
    public partial class Doelstellingscode
    {
        public Doelstellingscode()
        {
            OefeningDoelstellingscode = new HashSet<OefeningDoelstellingscode>();
        }

        public string Code { get; set; }

        public ICollection<OefeningDoelstellingscode> OefeningDoelstellingscode { get; set; }
    }
}
