using breakoutbox.Models;
using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class PadConfiguration:IEntityTypeConfiguration<Pad>
    {
        public void Configure(EntityTypeBuilder<Pad> builder)
        {
            builder.ToTable("PAD");

            builder.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.ActieNaam)
                    .HasColumnName("ACTIE_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

            builder.Property(e => e.Antwoord)
                    .HasColumnName("ANTWOORD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

            builder.Property(e => e.Contactleer).HasColumnName("CONTACTLEER");

            builder.Property(e => e.GroepsbewerkingNaam)
                    .HasColumnName("GROEPSBEWERKING_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

            builder.Property(e => e.OefeningNaam)
                    .HasColumnName("OEFENING_NAAM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

            builder.Property(e => e.ToegangscodeId)
                    .HasColumnName("TOEGANGSCODE_ID")
                    .HasColumnType("numeric(19, 0)");

            builder.HasOne(d => d.ActieNaamNavigation)
                    .WithMany(p => p.Pad)
                    .HasForeignKey(d => d.ActieNaam)
                    .HasConstraintName("FK_PAD_ACTIE_NAAM");

            builder.HasOne(d => d.GroepsbewerkingNaamNavigation)
                    .WithMany(p => p.Pad)
                    .HasForeignKey(d => d.GroepsbewerkingNaam)
                    .HasConstraintName("PADGROEPSBEWERKINGNAAM");

                builder.HasOne(d => d.OefeningNaamNavigation)
                    .WithMany(p => p.Pad)
                    .HasForeignKey(d => d.OefeningNaam)
                    .HasConstraintName("FK_PAD_OEFENING_NAAM");

                builder.HasOne(d => d.Toegangscode)
                    .WithMany(p => p.Pad)
                    .HasForeignKey(d => d.ToegangscodeId)
                    .HasConstraintName("FK_PAD_TOEGANGSCODE_ID");
        }
    }
}