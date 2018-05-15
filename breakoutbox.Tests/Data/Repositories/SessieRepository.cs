using System.Collections.Generic;
using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.Domain;

namespace breakoutbox.Tests.Data.Repositories
{
    public class SessieRepository: ISessieRepository
    {
        public IEnumerable<Sessie> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Sessie GetById(string naam)
        {
            throw new System.NotImplementedException();
        }

        public Sessie GetByCode(int code)
        {
            throw new System.NotImplementedException();
        }

        public Sessie GetByIdGroepenMetGroepstate(string naam)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Sessie> GetAllActive()
        {
            throw new System.NotImplementedException();
        }
    }
}