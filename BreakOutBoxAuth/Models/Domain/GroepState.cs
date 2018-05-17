using System;
using System.Collections.Generic;
using BreakOutBoxAuth.Models.Domain;
using Newtonsoft.Json;

namespace BreakOutBoxAuth.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Groepstate
    {
        protected Groepstate()
        {
        }

        public Groepstate(Groep groep)
        {
            Groep = groep;
        }

        [JsonProperty] public int Id { get; set; }
         public Groep Groep { get; set; }
        [JsonProperty] public decimal? GroepId { get; set; }

        public virtual void Finish()
        {
        }


        public virtual void Blok()
        {
        }


        public virtual void Spelen()
        {
        }


        public virtual void KanSpelen()
        {
        }

        public virtual void Start()
        {
        }

        public virtual void GekozenEnVergrendeld()
        {
        }

        public abstract Type GetClassType();

        public abstract string GetStatus();

        public abstract State getStateEnum();
    }
}