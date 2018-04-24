using System;
using System.Collections.Generic;

namespace breakoutbox.Models
{
    public partial class Toegangscode
    {
        public Toegangscode()
        {
            Pad = new HashSet<Pad>();
        }

        public decimal Id { get; set; }
        public int? Code { get; set; }

        public ICollection<Pad> Pad { get; set; }
    }
}
