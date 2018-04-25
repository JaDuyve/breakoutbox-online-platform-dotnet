﻿﻿using System;
using breakoutbox.Data.Mappers;
using breakoutbox.Models;
using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace breakoutbox.Data
{
    public class ApplicationDbContext: DbContext
    {
        
        public DbSet<Groep> Groepen { get; set; }
        public DbSet<Pad> Paden { get; set; }
        public DbSet<Sessie> Sessies { get; set; }

        
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
              
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ActieConfiguration());
            modelBuilder.ApplyConfiguration(new BobActieConfiguration());
            modelBuilder.ApplyConfiguration(new BobConfiguration());
            modelBuilder.ApplyConfiguration(new BobOefeningConfiguration());
            modelBuilder.ApplyConfiguration(new DoelstellingscodeConfiguration());
            modelBuilder.ApplyConfiguration(new GroepConfiguration());
            modelBuilder.ApplyConfiguration(new GroepPadConfiguration());
            modelBuilder.ApplyConfiguration(new GroepsBewerkingConfiguration());
            modelBuilder.ApplyConfiguration(new OefeningConfiguration());
            modelBuilder.ApplyConfiguration(new OefeningDoelstellingscodeConfiguration());
            modelBuilder.ApplyConfiguration(new OefeningGroepsbewerkingConfiguration());
            modelBuilder.ApplyConfiguration(new PadConfiguration());
            modelBuilder.ApplyConfiguration(new SessieConfiguration());
            modelBuilder.ApplyConfiguration(new SessieGroepConfiguration());
            modelBuilder.ApplyConfiguration(new ToegangscodeConfiguration());
            modelBuilder.ApplyConfiguration(new VakConfiguration());
        }
    }
}