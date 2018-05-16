﻿using System;

namespace BreakOutBoxAuth.Models
{
    public class Groepspeelstate: Groepstate
    {
        
        public Groepspeelstate(Groep groep):base(groep)
        {
            
        }

        public Groepspeelstate()
        {
            
        }
        
        public override void Finish()
        {
            Groep.ToState(new Groepfinishedstate(Groep));
        }

        public override void Blok()
        {
            Groep.ToState(new Groepgeblokkeerdstate(Groep));
        }

        public override void Spelen()
        {
            throw new System.NotImplementedException();
        }

        public override void KanSpelen()
        {
            throw new System.NotImplementedException();
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
            return "Spelen";
        }

        public override void GekozenEnVergrendeld()
        {
            throw new System.NotImplementedException();
        }
        
        
    }
}