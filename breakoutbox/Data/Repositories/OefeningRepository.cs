﻿using System.Collections.Generic;
using System.Linq;
using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace breakoutbox.Data.Repositories
{
    public class OefeningRepository : IOefeningRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Oefening> _oefenigen;

        public OefeningRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _oefenigen = _dbContext.Oefeningen;
        }

        public Oefening GetById(int oefId)
        {
            return _oefenigen.SingleOrDefault(o => o.OefeningId == oefId);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        IEnumerable<Oefening> IOefeningRepository.GetAll()
        {
            return _oefenigen.ToList();
        }
    }
}