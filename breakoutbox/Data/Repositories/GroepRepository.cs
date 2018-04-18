using breakoutbox.Models.Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

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
        
//        public Groep GetById(long ID)
//        {
//            // nog uitwerken
//            return _groepen;
//        }
    }
}