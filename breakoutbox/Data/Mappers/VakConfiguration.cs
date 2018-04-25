using breakoutbox.Models;
using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class VakConfiguration:IEntityTypeConfiguration<Vak>
    {
        public void Configure(EntityTypeBuilder<Vak> builder)
        {
            builder.HasKey(e => e.Naam);

            builder.ToTable("VAK");

            builder.Property(e => e.Naam)
                .HasColumnName("NAAM")
                .HasMaxLength(255)
                .IsUnicode(false)
                .ValueGeneratedNever();

            builder.Property(e => e.Kleur)
                .HasColumnName("KLEUR")
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}