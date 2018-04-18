using System.Collections.Generic;

namespace breakoutbox.Models.Domain
{
    public interface ISessieRepository
    {
        IEnumerable<Sessie> GetAll();
        Sessie GetById(int sessieId);
        void SaveChanges();
    }
}