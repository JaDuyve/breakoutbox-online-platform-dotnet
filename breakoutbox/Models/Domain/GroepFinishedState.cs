using System;
using System.Collections.Generic;

namespace breakoutbox.Models
{
    public partial class Groepfinishedstate
    {
        public decimal Id { get; set; }

        public Groepstate IdNavigation { get; set; }
    }
}
