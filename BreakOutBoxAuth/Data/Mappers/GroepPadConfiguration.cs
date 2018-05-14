using BreakOutBoxAuth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBoxAuth.Data.Mappers
{
    public class GroepPadConfiguration : IEntityTypeConfiguration<GroepPad>
    {
        public void Configure(EntityTypeBuilder<GroepPad> builder)
        {
            builder.HasKey(e => new {e.GroepId, e.PadenId});

            
            builder.ToTable("GROEP_PAD");

            builder.Property(e => e.GroepId)
                .HasColumnName("Groep_ID")
                .HasColumnType("numeric(19, 0)");

            builder.Property(e => e.PadenId)
                .HasColumnName("paden_ID")
                .HasColumnType("numeric(19, 0)");

            builder.Property(e => e.PadenKey).HasColumnName("PADEN_KEY");

            builder.HasOne(d => d.Groep)
                .WithMany(p => p.GroepPad)
                .HasForeignKey(d => d.GroepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GROEP_PAD_Groep_ID");

            builder.HasOne(d => d.Paden)
                .WithMany(p => p.GroepPad)
                .HasForeignKey(d => d.PadenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GROEP_PAD_paden_ID");
        }
    }
}