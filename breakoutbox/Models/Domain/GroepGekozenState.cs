using System;
using System.Collections.Generic;

namespace breakoutbox.Models
{
    public partial class Groepgekozenstate
    {
        public decimal Id { get; set; }

        public Groepstate IdNavigation { get; set; }
    }
}
