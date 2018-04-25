using breakoutbox.Models;
using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace breakoutbox.Data.Mappers
{
    public class SessieConfiguration: IEntityTypeConfiguration<Sessie>
    {
        public void Configure(EntityTypeBuilder<Sessie> builder)
        {
            builder.HasKey(e => e.Naam);

            builder.ToTable("SESSIE");

            builder.Property(e => e.Naam)
                .HasColumnName("NAAM")
                .HasMaxLength(255)
                .IsUnicode(false)
                .ValueGeneratedNever();

            builder.Property(e => e.BobNaam)
                .HasColumnName("BOB_NAAM")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Code).HasColumnName("CODE");

            builder.Property(e => e.Contactleer).HasColumnName("CONTACTLEER");

            builder.Property(e => e.Startdatum)
                .HasColumnName("STARTDATUM")
                .HasColumnType("datetime");

            builder.HasOne(d => d.BobNaamNavigation)
                .WithMany(p => p.Sessie)
                .HasForeignKey(d => d.BobNaam)
                .HasConstraintName("FK_SESSIE_BOB_NAAM");
        }
    }
}