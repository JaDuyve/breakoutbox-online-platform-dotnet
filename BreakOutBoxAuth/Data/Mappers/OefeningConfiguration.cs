using BreakOutBoxAuth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBoxAuth.Data.Mappers
{
    public class OefeningConfiguration : IEntityTypeConfiguration<Oefening>
    {
        public void Configure(EntityTypeBuilder<Oefening> builder)
        {
            builder.HasKey(e => e.Naam);

            builder.ToTable("OEFENING");

            builder.Property(e => e.Naam)
                .HasColumnName("NAAM")
                .HasMaxLength(255)
                .IsUnicode(false)
                .ValueGeneratedNever();

            builder.Property(e => e.Antwoord)
                .HasColumnName("ANTWOORD")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Feedback)
                .HasColumnName("FEEDBACK")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Opgave)
                .HasColumnName("OPGAVE")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Tijdslimiet).HasColumnName("TIJDSLIMIET");

            builder.Property(e => e.VakNaam)
                .HasColumnName("VAK_NAAM")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.HasOne(d => d.VakNaamNavigation)
                .WithMany(p => p.Oefening)
                .HasForeignKey(d => d.VakNaam)
                .HasConstraintName("FK_OEFENING_VAK_NAAM");
        }
    }
}