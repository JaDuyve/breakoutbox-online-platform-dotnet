using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class OefeningDoelstellingscodeConfiguration : IEntityTypeConfiguration<OefeningDoelstellingscode>
    {
        public void Configure(EntityTypeBuilder<OefeningDoelstellingscode> builder)
        {
            builder.HasKey(e => new {e.OefeningNaam, e.DoelstellingscodesCode});

            builder.ToTable("OEFENING_DOELSTELLINGSCODE");

            builder.Property(e => e.OefeningNaam)
                .HasColumnName("Oefening_NAAM")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.DoelstellingscodesCode)
                .HasColumnName("doelstellingscodes_CODE")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.HasOne(d => d.DoelstellingscodesCodeNavigation)
                .WithMany(p => p.OefeningDoelstellingscode)
                .HasForeignKey(d => d.DoelstellingscodesCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FNNGDLSTdlstllngscdsCD");

            builder.HasOne(d => d.OefeningNaamNavigation)
                .WithMany(p => p.OefeningDoelstellingscode)
                .HasForeignKey(d => d.OefeningNaam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FNNGDLSTLLNGSCDEfnngNM");
        }
    }
}