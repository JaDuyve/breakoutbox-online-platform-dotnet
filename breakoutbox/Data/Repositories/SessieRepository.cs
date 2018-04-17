using System.Collections.Generic;
using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace breakoutbox.Data.Repositories
{
    public class SessieRepository: ISessieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Sessie> _sessies;

        public SessieRepository(ApplicationDbContext context)
        {
            _context = _context;
            _sessies = _context.Sessies;
        }

        public IEnumerable<Sessie> GetAll()
        {
            return _sessies.Include(s => s.Groepen);
            
        }

        public Sessie GetById(int sessieId)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}