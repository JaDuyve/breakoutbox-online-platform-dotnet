using System.ComponentModel.DataAnnotations;

namespace BreakOutBoxAuth.Models.OefeningViewModel
{
    public class AntwoordViewModel
    {
        public AntwoordViewModel(Pad pad, Groep groep)
        {
            Pad = pad;
            Groep = groep;
        }

        public AntwoordViewModel()
        {
        }
        
        [Required(ErrorMessage="{0} moet ingevuld worden.")]
        
        public string Antwoord { get; set; }
        public Pad Pad { get; set; }
        public Groep Groep { get; set; }
    }
}