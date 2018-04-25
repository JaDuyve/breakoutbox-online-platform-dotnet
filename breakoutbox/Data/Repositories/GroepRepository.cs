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
                 .SingleOrDefault(g => g.Id == ID);
         }
 
     }
 }