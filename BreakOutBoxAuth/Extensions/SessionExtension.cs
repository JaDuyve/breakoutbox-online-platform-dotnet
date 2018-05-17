using BreakOutBoxAuth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Extensions
{
    public  class SessionExtension: ActionFilterAttribute
    {

        private Groep _groep;

        public SessionExtension()
        {
            
        }
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _groep = ReadGroepFromSession(context.HttpContext);
            context.ActionArguments["groep"] = _groep;
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (_groep != null)
            {
                WriteGroepToSession(_groep, context.HttpContext);
                base.OnActionExecuted(context);
            }
            
        }
        
        
       
        

        private Groep ReadGroepFromSession(HttpContext context)
        {
            Groep groep = context.Session.GetString("groep") == null ?
                null : JsonConvert.DeserializeObject<Groep>(context.Session.GetString("groep"));
            return groep;
        }

        private void WriteGroepToSession(Groep groep, HttpContext context)
        {
            context.Session.SetString("groep", JsonConvert.SerializeObject(groep));
        }
    }
}