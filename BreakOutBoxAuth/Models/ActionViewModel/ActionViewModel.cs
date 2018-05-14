using Microsoft.VisualStudio.Web.CodeGeneration;

namespace BreakOutBoxAuth.Models.ActionViewModel
{
    public class ActionViewModel
    {
        public ActionViewModel(Pad pad, Groep groep, bool isSchatkist, string opgave = "")
        {
            Pad = pad;
            Groep = groep;
            Actie = pad.ActieNaamNavigation;
            IsSchatkist = isSchatkist;
            Opgave = opgave;
        }

        public ActionViewModel()
        {
            
        }

        public int Toegangscode { get; set; }
        public Actie Actie { get; set; }
        public Pad Pad { get; set; }
        public Groep Groep { get; set; }
        public bool IsSchatkist { get; set; }
        public string Opgave { get; set; }
    }
}

