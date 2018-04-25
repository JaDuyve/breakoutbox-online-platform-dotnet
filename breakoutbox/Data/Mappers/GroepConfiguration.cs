using breakoutbox.Models;
using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class GroepConfiguration:IEntityTypeConfiguration<Groep>
    {
        public void Configure(EntityTypeBuilder<Groep> builder)
        {
            builder.ToTable("GROEP");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasColumnType("numeric(19, 0)")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Contactleer).HasColumnName("CONTACTLEER");

            builder.Property(e => e.Klas)
                .HasColumnName("KLAS")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Naam)
                .HasColumnName("NAAM")
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}