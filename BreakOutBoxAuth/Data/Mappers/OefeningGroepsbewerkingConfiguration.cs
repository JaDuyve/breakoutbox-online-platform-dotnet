using BreakOutBoxAuth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBoxAuth.Data.Mappers
{
    public class OefeningGroepsbewerkingConfiguration : IEntityTypeConfiguration<OefeningGroepsbewerking>
    {
        public void Configure(EntityTypeBuilder<OefeningGroepsbewerking> builder)
        {
            builder.HasKey(e => new {e.OefeningNaam, e.LijstGroepsbewerkingenNaam});

            builder.ToTable("OEFENING_GROEPSBEWERKING");

            builder.Property(e => e.OefeningNaam)
                .HasColumnName("Oefening_NAAM")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.LijstGroepsbewerkingenNaam)
                .HasColumnName("lijstGroepsbewerkingen_NAAM")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.HasOne(d => d.LijstGroepsbewerkingenNaamNavigation)
                .WithMany(p => p.OefeningGroepsbewerking)
                .HasForeignKey(d => d.LijstGroepsbewerkingenNaam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FNNGGljstGrpsbwrkngnNM");

            builder.HasOne(d => d.OefeningNaamNavigation)
                .WithMany(p => p.OefeningGroepsbewerking)
                .HasForeignKey(d => d.OefeningNaam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FNNGGRPSBWERKINGfnngNM");
        }
    }
}