using breakoutbox.Models;
using breakoutbox.Models.Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace breakoutbox.Data.Repositories
{
    public class GroepRepository: IGroepRepository
    {
        private readonly BoBContext _context;
        private readonly DbSet<Groep> _groepen;

        public GroepRepository(BoBContext context)
        {
            _context = context;
            _groepen = context.Groep;
        }
        
        public Groep GetById(long ID)
        {
            return _groepen.Include(g => g.GroepPad).ThenInclude(gp => gp.Paden).ThenInclude(p => p.OefeningNaamNavigation).SingleOrDefault(g => g.Id == ID);
        }

    }
}