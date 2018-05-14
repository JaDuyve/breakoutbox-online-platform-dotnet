using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class BobActieConfiguration : IEntityTypeConfiguration<BobActie>
    {
        public void Configure(EntityTypeBuilder<BobActie> builder)
        {
            builder.HasKey(e => new {e.BobNaam, e.LijstActiesNaam});

            builder.ToTable("BOB_ACTIE");

            builder.Property(e => e.BobNaam)
                .HasColumnName("Bob_NAAM")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.LijstActiesNaam)
                .HasColumnName("lijstActies_NAAM")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.HasOne(d => d.BobNaamNavigation)
                .WithMany(p => p.BobActie)
                .HasForeignKey(d => d.BobNaam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BOB_ACTIE_Bob_NAAM");

            builder.HasOne(d => d.LijstActiesNaamNavigation)
                .WithMany(p => p.BobActie)
                .HasForeignKey(d => d.LijstActiesNaam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BBACTIElijstActiesNAAM");
        }
    }
}