using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace breakoutbox.Data.Mappers
{
    public class SessieGroepConfiguration:IEntityTypeConfiguration<SessieGroep>
    {
        public void Configure(EntityTypeBuilder<SessieGroep> builder)
        {
            builder.HasKey(e => new { e.SessieNaam, e.GroepenId });

            builder.ToTable("SESSIE_GROEP");

            builder.Property(e => e.SessieNaam)
                .HasColumnName("Sessie_NAAM")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.GroepenId)
                .HasColumnName("groepen_ID")
                .HasColumnType("numeric(19, 0)");

            builder.HasOne(d => d.Groepen)
                .WithMany(p => p.SessieGroep)
                .HasForeignKey(d => d.GroepenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SESSIE_GROEPgroepen_ID");

            builder.HasOne(d => d.SessieNaamNavigation)
                .WithMany(p => p.SessieGroep)
                .HasForeignKey(d => d.SessieNaam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SESSIEGROEPSessie_NAAM");
        }
    }
}