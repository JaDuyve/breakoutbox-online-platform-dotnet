using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BreakOutBoxAuth.Data.Repositories
{
    public class GroepstateRepository: IGroepstateRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Groepstate> _groepstates; 
        
        public GroepstateRepository(ApplicationDbContext context)
        {
            _context = context;
            _groepstates = _context.Groepstates;
        }
        
        public void Delete(Groepstate groepstate)
        {
            _groepstates.Remove(groepstate);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}