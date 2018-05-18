using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Extensions
{
    public class SessionExtension : ActionFilterAttribute
    {

        private Groep _groep;
        private readonly IGroepRepository _groepRepository;

        public SessionExtension(IGroepRepository groepRepository)
        {
            _groepRepository = groepRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _groep = ReadGroepFromSession(context.HttpContext);
            if(_groep.Id != 0)
                _groep = _groepRepository.GetById(_groep.Id);

            context.ActionArguments["groep"] = _groep;
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
           // if (_groep != null)
            //{
                WriteGroepToSession(_groep, context.HttpContext);
                base.OnActionExecuted(context);
            //}

        }





        private Groep ReadGroepFromSession(HttpContext context)
        {
            //var eventConverter = new GroepStConverter();
            //var deseralizeSettings = new JsonSerializerSettings();
            //deseralizeSettings.Converters.Add(eventConverter);
            //deseralizeSettings.TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
            //deseralizeSettings.TypeNameHandling = TypeNameHandling.Auto;

            //Groepstate groepstate = context.Session.GetString("groepstate") == null ? null : JsonConvert.DeserializeObject<Groepstate>(context.Session.GetString("groepstate"), deseralizeSettings);

            Groep groep = context.Session.GetString("groep") == null ?
                new Groep() : JsonConvert.DeserializeObject<Groep>(context.Session.GetString("groep"));
            //if (groepstate != null)
            //{
            //    groep.Currentstate = groepstate;

            //}
            return groep;
        }

        private void WriteGroepToSession(Groep groep, HttpContext context)
        {
            //context.Session.SetString("groepstate", JsonConvert.SerializeObject(groep.Currentstate, Formatting.Indented, new JsonSerializerSettings
            //{
            //    TypeNameHandling = TypeNameHandling.Objects,
            //    TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            //}));
            context.Session.SetString("groep", JsonConvert.SerializeObject(groep));
        }
    }
}