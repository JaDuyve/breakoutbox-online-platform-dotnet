using System;
using System.Collections.Generic;

namespace breakoutbox.Models
{
    public partial class OefeningDoelstellingscode
    {
        public OefeningDoelstellingscode()
        {
                
        }
        public string OefeningNaam { get; set; }
        public string DoelstellingscodesCode { get; set; }

        public Doelstellingscode DoelstellingscodesCodeNavigation { get; set; }
        public Oefening OefeningNaamNavigation { get; set; }
    }
}
