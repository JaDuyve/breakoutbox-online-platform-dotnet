﻿using System;
using breakoutbox.Data.Mappers;
using breakoutbox.Models;
using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace breakoutbox.Data
{
    public class ApplicationDbContext: DbContext
    {
        
        public DbSet<Actie> Acties { get; set; }
        public DbSet<Bob> Bobs { get; set; }
        public DbSet<Groep> Groepen { get; set; } 
        public DbSet<Groepsbewerking> Groepsbewerkingen { get; set; }
        public DbSet<Oefening> Oefeningen { get; set; }
        public DbSet<Pad> Paden { get; set; }
        public DbSet<Sessie> Sessies { get; set; }
        public DbSet<Toegangscode> Toegangscodes { get; set; }
        public DbSet<Vak> Vakken { get; set; }
        
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
              
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ActieConfiguration());
            modelBuilder.ApplyConfiguration(new BobConfiguration());
            modelBuilder.ApplyConfiguration(new GroepConfiguration());
            modelBuilder.ApplyConfiguration(new GroepsBewerkingConfiguration());
            modelBuilder.ApplyConfiguration(new OefeningConfiguration());
            modelBuilder.ApplyConfiguration(new PadConfiguration());
            modelBuilder.ApplyConfiguration(new SessieConfiguration());
            modelBuilder.ApplyConfiguration(new ToegangscodeConfiguration());
            modelBuilder.ApplyConfiguration(new VakConfiguration());
        }
    }
}