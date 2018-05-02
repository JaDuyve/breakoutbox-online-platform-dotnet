using Microsoft.VisualStudio.Web.CodeGeneration;

namespace breakoutbox.Models.ActionViewModel
{
    public class ActionViewModel
    {
        public ActionViewModel(Pad pad, Groep groep)
        {
            Pad = pad;
            Groep = groep;
            Actie = pad.ActieNaamNavigation;
        }

        public ActionViewModel()
        {
            
        }

        public int Toegangscode { get; set; }
        public Actie Actie { get; set; }
        public Pad Pad { get; set; }
        public Groep Groep { get; set; }
    }
}

