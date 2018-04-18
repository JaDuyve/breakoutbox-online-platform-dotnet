﻿using System.Collections.Generic;
using System.Linq;
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
            _context = context;
            _sessies = _context.Sessies;
        }
        

        public IEnumerable<Sessie> GetAll()
        {
            return _sessies/*.Include(s => s.Groepen)*/.ToList();
            
        }

        public Sessie GetById(string naam)
        {
            return _sessies.Include(s => s.Groepen).SingleOrDefault(s => s.Naam == naam);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}