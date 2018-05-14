using System.Linq;
using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BreakOutBoxAuth.Data.Repositories
{
    public class GroepRepository : IGroepRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Groep> _groepen;

        public GroepRepository(ApplicationDbContext context)
        {
            _context = context;
            _groepen = context.Groepen;
        }

        public Groep GetById(decimal ID)
        {
            return _groepen
                .Include(g => g.GroepPad).ThenInclude(gp => gp.Paden)
                .ThenInclude(p => p.OefeningNaamNavigation)
                .Include(g => g.GroepPad).ThenInclude(gp => gp.Paden)
                .ThenInclude(p => p.GroepsbewerkingNaamNavigation)
                .Include(g => g.GroepPad).ThenInclude(gp => gp.Paden)
                .ThenInclude(p => p.ActieNaamNavigation)
                .Include(g => g.GroepPad).ThenInclude(gp => gp.Paden)
                .ThenInclude(p => p.Toegangscode)
                .Include(g => g.Currentstate).ThenInclude(g => g.Groep)
                .SingleOrDefault(g => g.Id == ID);
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