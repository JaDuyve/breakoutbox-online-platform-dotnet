using System;

namespace breakoutbox.Models.Domain
{
    public interface IGroepRepository
    {
        Groep GetById(Decimal ID);
        
        
    }
}