using System.Collections.Generic;

namespace breakoutbox.Models
{
    public class Doelstellingscode
    {
        public Doelstellingscode()
        {
            OefeningDoelstellingscode = new HashSet<OefeningDoelstellingscode>();
        }

        public string Code { get; set; }

        public ICollection<OefeningDoelstellingscode> OefeningDoelstellingscode { get; set; }
    }
}