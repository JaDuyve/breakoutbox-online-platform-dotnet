﻿using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace breakoutbox.Models
{
    public class Groepfinishedstate: Groepstate
    {
        public Groepfinishedstate()
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
            throw new System.NotImplementedException();
        }

        public override void GekozenEnVergrendeld()
        {
            throw new System.NotImplementedException();
        }

        public override Type GetClassType()
        {
            return GetType();
        }


        public Groepfinishedstate(Groep groep):base(groep)
        {
            
        }
    }
}