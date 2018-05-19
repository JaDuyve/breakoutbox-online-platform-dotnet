using System;
using System.Collections.Generic;
using System.Linq;
using BreakOutBoxAuth.Models;
using BreakOutBoxAuth.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BreakOutBoxAuth.Data.Repositories
{
    public class SessieRepository : ISessieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Sessie> _sessies;

        public SessieRepository(ApplicationDbContext context)
        {
            _context = context;
            _sessies = _context.Sessies;
        }

       

        public Sessie GetByCode(int code)
        {
            return _sessies.Where(s => s.Code == code).SingleOrDefault();
        }

        public Sessie GetByIdGroepenMetGroepstate(string naam)
        {
            return _sessies.Where(s => s.Naam.Equals(naam))
                .Include(s => s.SessieGroep)
                .ThenInclude(g => g.Groepen)
                .ThenInclude(g => g.Currentstate)
                .Include(g => g.SessieGroep)
                .ThenInclude(g => g.Groepen)
                .ThenInclude(g => g.GroepPad)
                .SingleOrDefault();
        }

        public IEnumerable<Sessie> GetAll()
        {
            return _sessies.ToList();
        }

        public Sessie GetById(string naam)
        {
            return _sessies.Include(s => s.SessieGroep).ThenInclude(g => g.Groepen)
                .SingleOrDefault(s => s.Naam.Equals( naam));
        }
        
        


        public void SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }

        public IEnumerable<Sessie> GetAllActive()
        {
            
            return _sessies.Where(s => s.Startdatum.Date <= DateTime.Now.Date).ToList();
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}