using System.Collections.Generic;

namespace BreakOutBoxAuth.Models.Domain
{
    public interface ISessieRepository
    {
        IEnumerable<Sessie> GetAll();
        Sessie GetById(string naam);
        Sessie GetByCode(int code);
        Sessie GetByIdGroepenMetGroepstate(string naam);
        void SaveChanges();
        void SaveChangesAsync();
        IEnumerable<Sessie> GetAllActive();
        IEnumerable<Sessie> GetAllToday();
        
    }
}