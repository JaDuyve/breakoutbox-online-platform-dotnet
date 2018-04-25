using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class BobOefeningConfiguration:IEntityTypeConfiguration<BobOefening>
    {
        public void Configure(EntityTypeBuilder<BobOefening> builder)
        {
            builder.HasKey(e => new { e.BobNaam, e.LijstOefeningenNaam });

            builder.ToTable("BOB_OEFENING");

            builder.Property(e => e.BobNaam)
                .HasColumnName("Bob_NAAM")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.LijstOefeningenNaam)
                .HasColumnName("lijstOefeningen_NAAM")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.HasOne(d => d.BobNaamNavigation)
                .WithMany(p => p.BobOefening)
                .HasForeignKey(d => d.BobNaam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BOB_OEFENING_Bob_NAAM");

            builder.HasOne(d => d.LijstOefeningenNaamNavigation)
                .WithMany(p => p.BobOefening)
                .HasForeignKey(d => d.LijstOefeningenNaam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BBFNNGljstfeningenNAAM");
        }
    }
}