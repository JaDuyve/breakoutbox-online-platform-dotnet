using breakoutbox.Models;
using breakoutbox.Models.Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace breakoutbox.Data.Repositories
{
    public class GroepRepository: IGroepRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Groep> _groepen;

        public GroepRepository(ApplicationDbContext context)
        {
            _context = context;
            _groepen = context.Groepen;
        }
        
        public Groep GetById(long ID)
        {
            return _groepen.SingleOrDefault(g => g.Id == ID);
        }

    }
}