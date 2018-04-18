using System.Linq;
using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace breakoutbox.Data.Repositories
{
    public class PadRepository: IPadRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Pad> _padden;

        public PadRepository(ApplicationDbContext context)
        {
            _context = context;
            _padden = context.Paden;
        }
        
        public Pad GetById(int padId)
        {
            return _padden
                .Include(p => p.Oefening)
                .Include(p => p.Toegangscode)
                .Include(p => p.Groepsbewerking)
                .SingleOrDefault(p => p.PadId == padId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}