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

        public IEnumerable<Sessie> GetAll()
        {
            return _sessies /*.Include(s => s.Groepen)*/.ToList();
        }

        public Sessie GetById(string naam)
        {
            return _sessies.Include(s => s.SessieGroep).ThenInclude(g => g.Groepen)
                .SingleOrDefault(s => s.Naam == naam);
        }

        /*public Sessie GetById(string naam)
        {
            return _sessies.Include(s => s.SessieGroep).SingleOrDefault(s => s.Naam == naam);
        }*/


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}