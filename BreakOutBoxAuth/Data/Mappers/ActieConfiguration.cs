using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class ActieConfiguration : IEntityTypeConfiguration<Actie>
    {
        public void Configure(EntityTypeBuilder<Actie> builder)
        {
            builder.HasKey(e => e.Naam);

            builder.ToTable("ACTIE");

            builder.Property(e => e.Naam)
                .HasColumnName("NAAM")
                .HasMaxLength(255)
                .IsUnicode(false)
                .ValueGeneratedNever();

            builder.Property(e => e.Opgave)
                .HasColumnName("OPGAVE")
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}