using breakoutbox.Data.Mappers;
using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;

namespace breakoutbox.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Groep> Groepen { get; set; }
        public DbSet<Pad> Paden { get; set; }
        public DbSet<Sessie> Sessies { get; set; }

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
            modelBuilder.ApplyConfiguration(new GroepstateConfiguration());
            modelBuilder.ApplyConfiguration(new GroepfinishedstateConfiguration());
            modelBuilder.ApplyConfiguration(new GroepgeblokkeerdstateConfiguration());
            modelBuilder.ApplyConfiguration(new GroepgekozenstateConfiguration());
            modelBuilder.ApplyConfiguration(new GroepkanspelenstateConfiguration());
            modelBuilder.ApplyConfiguration(new GroepspeelstateConfiguration());
            modelBuilder.ApplyConfiguration(new VakConfiguration());
//            modelBuilder.Entity<Groep>().Has
//            modelBuilder.ApplyConfiguration(new LeerlingConfiguration());

        }
    }
}