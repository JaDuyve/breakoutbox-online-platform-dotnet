using System;
using System.Collections.Generic;

namespace breakoutbox.Models
{
    public partial class Groepstate
    {
        public Groepstate()
        {
            Groep = new HashSet<Groep>();
        }

        public decimal Id { get; set; }
        public string Dtype { get; set; }
        public decimal? GroepId { get; set; }

        public Groep GroepNavigation { get; set; }
        public Groepfinishedstate Groepfinishedstate { get; set; }
        public Groepgeblokkeerdstate Groepgeblokkeerdstate { get; set; }
        public Groepgekozenstate Groepgekozenstate { get; set; }
        public Groepkanspelenstate Groepkanspelenstate { get; set; }
        public Groepspeelstate Groepspeelstate { get; set; }
        public ICollection<Groep> Groep { get; set; }
    }
}
