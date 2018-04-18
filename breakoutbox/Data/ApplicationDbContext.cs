using System;
using breakoutbox.Data.Mappers;
using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace breakoutbox.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Sessie> Sessies { get; set; }
        public DbSet<Pad> Padden { get; set; }
        public DbSet<Groep> Groepen { get; set; }
        
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OefeningConfiguration());
            modelBuilder.ApplyConfiguration(new BobConfiguration());
            modelBuilder.ApplyConfiguration(new SessieConfiguration());
        }
    }
}