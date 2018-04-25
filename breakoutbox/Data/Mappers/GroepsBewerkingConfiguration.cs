using breakoutbox.Models;
using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class GroepsBewerkingConfiguration:IEntityTypeConfiguration<Groepsbewerking>
    {
        public void Configure(EntityTypeBuilder<Groepsbewerking> builder)
        {
            builder.HasKey(e => e.Naam);

            builder.ToTable("GROEPSBEWERKING");

            builder.Property(e => e.Naam)
                .HasColumnName("NAAM")
                .HasMaxLength(255)
                .IsUnicode(false)
                .ValueGeneratedNever();

            builder.Property(e => e.Bewerking)
                .HasColumnName("BEWERKING")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Opgave)
                .HasColumnName("OPGAVE")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Waarde)
                .HasColumnName("WAARDE")
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}