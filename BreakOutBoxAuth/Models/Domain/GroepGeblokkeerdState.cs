﻿using System;

namespace BreakOutBoxAuth.Models
{
    public class Groepgeblokkeerdstate: Groepstate
    {


        public Groepgeblokkeerdstate(Groep groep):base(groep)
        {
            
        }

        public Groepgeblokkeerdstate()
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
            
            Groep.ToState(new Groepspeelstate(Groep));
            
            
        }

        public override void KanSpelen()
        {
            throw new System.NotImplementedException();
        }
        
        public override Type GetClassType()
        {
            return GetType();
        }

        public override string GetStatus()
        {
            return "Geblokkeerd";
        }

        public override void GekozenEnVergrendeld()
        {
            throw new System.NotImplementedException();
        }
    }
}