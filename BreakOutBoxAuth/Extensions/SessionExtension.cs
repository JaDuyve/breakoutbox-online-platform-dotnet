using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Extensions
{
    public  class SessionExtension: ActionFilterAttribute
    {

        

        public SessionExtension()
        {
            
        }
        
        /*public override void OnActionExecuting(ActionExecutingContext context)
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
            
        }*/
        
        

        public Sessie ReadSessieFromSession(HttpContext context)
        {
            
 
            
            Sessie sessie = context.Session.GetString("sessie") == null ?
                null : JsonConvert.DeserializeObject<Sessie>(context.Session.GetString("sessie"));
            
            return sessie;
        }

        public void WriteSessieToSession(Sessie sessie, HttpContext context)
        {
            
            context.Session.SetString("sessie", JsonConvert.SerializeObject(sessie));
        }
        
        public Groep ReadGroepFromSession(HttpContext context)
        {
            
            Groep groep = context.Session.GetString("groep") == null ?
                null : JsonConvert.DeserializeObject<Groep>(context.Session.GetString("groep"));
            
            return groep;
        }

        public void WriteGroepToSession(Groep sessie, HttpContext context)
        {
            
            context.Session.SetString("groep", JsonConvert.SerializeObject(sessie));
        }
    }
}