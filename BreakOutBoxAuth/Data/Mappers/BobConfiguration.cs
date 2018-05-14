using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class BobConfiguration : IEntityTypeConfiguration<Bob>
    {
        public void Configure(EntityTypeBuilder<Bob> builder)
        {
            builder.HasKey(e => e.Naam);

            builder.ToTable("BOB");

            builder.Property(e => e.Naam)
                .HasColumnName("NAAM")
                .HasMaxLength(255)
                .IsUnicode(false)
                .ValueGeneratedNever();
        }
    }
}