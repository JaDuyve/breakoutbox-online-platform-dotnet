using System.Collections.Generic;

namespace breakoutbox.Models.Domain
{
    public interface ISessieRepository
    {
        IEnumerable<Sessie> GetAll();
        Sessie GetById(string naam);
        Sessie GetByCode(int code);
        void SaveChanges();
    }
}