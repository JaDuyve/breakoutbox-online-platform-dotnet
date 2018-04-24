using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace breakoutbox.Models
{
    public partial class BoBContext : DbContext
    {
        public virtual DbSet<Actie> Actie { get; set; }
        public virtual DbSet<Bob> Bob { get; set; }
        public virtual DbSet<BobActie> BobActie { get; set; }
        public virtual DbSet<BobOefening> BobOefening { get; set; }
        public virtual DbSet<Doelstellingscode> Doelstellingscode { get; set; }
        public virtual DbSet<Groep> Groep { get; set; }
        public virtual DbSet<GroepPad> GroepPad { get; set; }
        public virtual DbSet<Groepsbewerking> Groepsbewerking { get; set; }
        public virtual DbSet<Oefening> Oefening { get; set; }
        public virtual DbSet<OefeningDoelstellingscode> OefeningDoelstellingscode { get; set; }
        public virtual DbSet<OefeningGroepsbewerking> OefeningGroepsbewerking { get; set; }
        public virtual DbSet<Pad> Pad { get; set; }
        public virtual DbSet<Sessie> Sessie { get; set; }
        public virtual DbSet<SessieGroep> SessieGroep { get; set; }
        public virtual DbSet<Toegangscode> Toegangscode { get; set; }
        public virtual DbSet<Vak> Vak { get; set; }

        // Unable to generate entity type for table 'dbo.Groep_LEERLINGEN'. Please see the warning messages.

        public BoBContext(DbContextOptions options) : base(options)
        {
              
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=tcp:breakoutbox.database.windows.net,1433;Initial Catalog=BoB;Persist Security Info=False;User ID=java;Password=Pazaak2.0;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actie>(entity =>
            {
                entity.HasKey(e => e.Naam);

                entity.ToTable("ACTIE");

                entity.Property(e => e.Naam)
                    .HasColumnName("NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Opgave)
                    .HasColumnName("OPGAVE")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bob>(entity =>
            {
                entity.HasKey(e => e.Naam);

                entity.ToTable("BOB");

                entity.Property(e => e.Naam)
                    .HasColumnName("NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<BobActie>(entity =>
            {
                entity.HasKey(e => new { e.BobNaam, e.LijstActiesNaam });

                entity.ToTable("BOB_ACTIE");

                entity.Property(e => e.BobNaam)
                    .HasColumnName("Bob_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LijstActiesNaam)
                    .HasColumnName("lijstActies_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.BobNaamNavigation)
                    .WithMany(p => p.BobActie)
                    .HasForeignKey(d => d.BobNaam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BOB_ACTIE_Bob_NAAM");

                entity.HasOne(d => d.LijstActiesNaamNavigation)
                    .WithMany(p => p.BobActie)
                    .HasForeignKey(d => d.LijstActiesNaam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BBACTIElijstActiesNAAM");
            });

            modelBuilder.Entity<BobOefening>(entity =>
            {
                entity.HasKey(e => new { e.BobNaam, e.LijstOefeningenNaam });

                entity.ToTable("BOB_OEFENING");

                entity.Property(e => e.BobNaam)
                    .HasColumnName("Bob_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LijstOefeningenNaam)
                    .HasColumnName("lijstOefeningen_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.BobNaamNavigation)
                    .WithMany(p => p.BobOefening)
                    .HasForeignKey(d => d.BobNaam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BOB_OEFENING_Bob_NAAM");

                entity.HasOne(d => d.LijstOefeningenNaamNavigation)
                    .WithMany(p => p.BobOefening)
                    .HasForeignKey(d => d.LijstOefeningenNaam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BBFNNGljstfeningenNAAM");
            });

            modelBuilder.Entity<Doelstellingscode>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("DOELSTELLINGSCODE");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Groep>(entity =>
            {
                entity.ToTable("GROEP");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Contactleer).HasColumnName("CONTACTLEER");

                entity.Property(e => e.Klas)
                    .HasColumnName("KLAS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Naam)
                    .HasColumnName("NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GroepPad>(entity =>
            {
                entity.HasKey(e => new { e.GroepId, e.PadenId });

                entity.ToTable("GROEP_PAD");

                entity.Property(e => e.GroepId)
                    .HasColumnName("Groep_ID")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.PadenId)
                    .HasColumnName("paden_ID")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.PadenKey).HasColumnName("PADEN_KEY");

                entity.HasOne(d => d.Groep)
                    .WithMany(p => p.GroepPad)
                    .HasForeignKey(d => d.GroepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GROEP_PAD_Groep_ID");

                entity.HasOne(d => d.Paden)
                    .WithMany(p => p.GroepPad)
                    .HasForeignKey(d => d.PadenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GROEP_PAD_paden_ID");
            });

            modelBuilder.Entity<Groepsbewerking>(entity =>
            {
                entity.HasKey(e => e.Naam);

                entity.ToTable("GROEPSBEWERKING");

                entity.Property(e => e.Naam)
                    .HasColumnName("NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Bewerking)
                    .HasColumnName("BEWERKING")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Opgave)
                    .HasColumnName("OPGAVE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Waarde)
                    .HasColumnName("WAARDE")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Oefening>(entity =>
            {
                entity.HasKey(e => e.Naam);

                entity.ToTable("OEFENING");

                entity.Property(e => e.Naam)
                    .HasColumnName("NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Antwoord)
                    .HasColumnName("ANTWOORD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Feedback)
                    .HasColumnName("FEEDBACK")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Opgave)
                    .HasColumnName("OPGAVE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tijdslimiet).HasColumnName("TIJDSLIMIET");

                entity.Property(e => e.VakNaam)
                    .HasColumnName("VAK_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.VakNaamNavigation)
                    .WithMany(p => p.Oefening)
                    .HasForeignKey(d => d.VakNaam)
                    .HasConstraintName("FK_OEFENING_VAK_NAAM");
            });

            modelBuilder.Entity<OefeningDoelstellingscode>(entity =>
            {
                entity.HasKey(e => new { e.OefeningNaam, e.DoelstellingscodesCode });

                entity.ToTable("OEFENING_DOELSTELLINGSCODE");

                entity.Property(e => e.OefeningNaam)
                    .HasColumnName("Oefening_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DoelstellingscodesCode)
                    .HasColumnName("doelstellingscodes_CODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.DoelstellingscodesCodeNavigation)
                    .WithMany(p => p.OefeningDoelstellingscode)
                    .HasForeignKey(d => d.DoelstellingscodesCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FNNGDLSTdlstllngscdsCD");

                entity.HasOne(d => d.OefeningNaamNavigation)
                    .WithMany(p => p.OefeningDoelstellingscode)
                    .HasForeignKey(d => d.OefeningNaam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FNNGDLSTLLNGSCDEfnngNM");
            });

            modelBuilder.Entity<OefeningGroepsbewerking>(entity =>
            {
                entity.HasKey(e => new { e.OefeningNaam, e.LijstGroepsbewerkingenNaam });

                entity.ToTable("OEFENING_GROEPSBEWERKING");

                entity.Property(e => e.OefeningNaam)
                    .HasColumnName("Oefening_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LijstGroepsbewerkingenNaam)
                    .HasColumnName("lijstGroepsbewerkingen_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.LijstGroepsbewerkingenNaamNavigation)
                    .WithMany(p => p.OefeningGroepsbewerking)
                    .HasForeignKey(d => d.LijstGroepsbewerkingenNaam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FNNGGljstGrpsbwrkngnNM");

                entity.HasOne(d => d.OefeningNaamNavigation)
                    .WithMany(p => p.OefeningGroepsbewerking)
                    .HasForeignKey(d => d.OefeningNaam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FNNGGRPSBWERKINGfnngNM");
            });

            modelBuilder.Entity<Pad>(entity =>
            {
                entity.ToTable("PAD");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ActieNaam)
                    .HasColumnName("ACTIE_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Antwoord)
                    .HasColumnName("ANTWOORD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Contactleer).HasColumnName("CONTACTLEER");

                entity.Property(e => e.GroepsbewerkingNaam)
                    .HasColumnName("GROEPSBEWERKING_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OefeningNaam)
                    .HasColumnName("OEFENING_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ToegangscodeId)
                    .HasColumnName("TOEGANGSCODE_ID")
                    .HasColumnType("numeric(19, 0)");

                entity.HasOne(d => d.ActieNaamNavigation)
                    .WithMany(p => p.Pad)
                    .HasForeignKey(d => d.ActieNaam)
                    .HasConstraintName("FK_PAD_ACTIE_NAAM");

                entity.HasOne(d => d.GroepsbewerkingNaamNavigation)
                    .WithMany(p => p.Pad)
                    .HasForeignKey(d => d.GroepsbewerkingNaam)
                    .HasConstraintName("PADGROEPSBEWERKINGNAAM");

                entity.HasOne(d => d.OefeningNaamNavigation)
                    .WithMany(p => p.Pad)
                    .HasForeignKey(d => d.OefeningNaam)
                    .HasConstraintName("FK_PAD_OEFENING_NAAM");

                entity.HasOne(d => d.Toegangscode)
                    .WithMany(p => p.Pad)
                    .HasForeignKey(d => d.ToegangscodeId)
                    .HasConstraintName("FK_PAD_TOEGANGSCODE_ID");
            });

            modelBuilder.Entity<Sessie>(entity =>
            {
                entity.HasKey(e => e.Naam);

                entity.ToTable("SESSIE");

                entity.Property(e => e.Naam)
                    .HasColumnName("NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BobNaam)
                    .HasColumnName("BOB_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code).HasColumnName("CODE");

                entity.Property(e => e.Contactleer).HasColumnName("CONTACTLEER");

                entity.Property(e => e.Startdatum)
                    .HasColumnName("STARTDATUM")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.BobNaamNavigation)
                    .WithMany(p => p.Sessie)
                    .HasForeignKey(d => d.BobNaam)
                    .HasConstraintName("FK_SESSIE_BOB_NAAM");
            });

            modelBuilder.Entity<SessieGroep>(entity =>
            {
                entity.HasKey(e => new { e.SessieNaam, e.GroepenId });

                entity.ToTable("SESSIE_GROEP");

                entity.Property(e => e.SessieNaam)
                    .HasColumnName("Sessie_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroepenId)
                    .HasColumnName("groepen_ID")
                    .HasColumnType("numeric(19, 0)");

                entity.HasOne(d => d.Groepen)
                    .WithMany(p => p.SessieGroep)
                    .HasForeignKey(d => d.GroepenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SESSIE_GROEPgroepen_ID");

                entity.HasOne(d => d.SessieNaamNavigation)
                    .WithMany(p => p.SessieGroep)
                    .HasForeignKey(d => d.SessieNaam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SESSIEGROEPSessie_NAAM");
            });

            modelBuilder.Entity<Toegangscode>(entity =>
            {
                entity.ToTable("TOEGANGSCODE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Code).HasColumnName("CODE");
            });

            modelBuilder.Entity<Vak>(entity =>
            {
                entity.HasKey(e => e.Naam);

                entity.ToTable("VAK");

                entity.Property(e => e.Naam)
                    .HasColumnName("NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Kleur)
                    .HasColumnName("KLEUR")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
