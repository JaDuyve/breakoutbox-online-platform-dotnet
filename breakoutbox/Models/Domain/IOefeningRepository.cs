using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace breakoutbox.Models.Domain
{
    public interface IOefeningRepository
    {
        Oefening GetById(int oefId);
        IEnumerable<Oefening> GetAll();
        void SaveChanges();
    }
}
