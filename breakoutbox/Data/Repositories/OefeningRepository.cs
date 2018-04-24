using System.Collections.Generic;
using System.Linq;
using breakoutbox.Models;
using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace breakoutbox.Data.Repositories
{
    public class OefeningRepository : IOefeningRepository
    {
        private readonly BoBContext _dbContext;
        private readonly DbSet<Oefening> _oefenigen;

        public OefeningRepository(BoBContext dbContext)
        {
            _dbContext = dbContext;
            _oefenigen = _dbContext.Oefening;
        }

        public Oefening GetById(string naam)
        {
            return _oefenigen.SingleOrDefault(o => o.Naam == naam);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        IEnumerable<Oefening> IOefeningRepository.GetAll()
        {
            return _oefenigen.ToList();
        }
    }
}