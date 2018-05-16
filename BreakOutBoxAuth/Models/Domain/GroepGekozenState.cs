﻿using System;
using BreakOutBoxAuth.Models.Domain;

namespace BreakOutBoxAuth.Models
{
    public class Groepgekozenstate: Groepstate
    {

        public Groepgekozenstate(Groep groep):base(groep)
        {
           
        }

        public Groepgekozenstate()
        {
            
        }

        public override void Finish()
        {
            throw new System.NotImplementedException();
        }

        public override void Blok()
        {
            throw new System.NotImplementedException();
        }

        public override void Spelen()
        {
            throw new System.NotImplementedException();
        }

        public override void KanSpelen()
        {
            Groep.ToState(new Groepkanspelenstate(Groep));
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override Type GetClassType()
        {
            return GetType();
        }

        public override string GetStatus()
        {
            return "Gekozen & vergrendeld";
        }

        public override State getStateEnum()
        {
            return State.GEKOZENVERGRENDELD;
        }

        public override void GekozenEnVergrendeld()
        {
            throw new System.NotImplementedException();
        }
    }
}