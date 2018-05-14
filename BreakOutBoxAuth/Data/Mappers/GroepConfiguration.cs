using BreakOutBoxAuth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBoxAuth.Data.Mappers
{
    public class GroepConfiguration : IEntityTypeConfiguration<Groep>
    {
        public void Configure(EntityTypeBuilder<Groep> builder)
        {
            builder.ToTable("GROEP");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasColumnType("numeric(19, 0)")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Contactleer).HasColumnName("CONTACTLEER");

            
            builder.HasOne(g => g.Currentstate)
                .WithOne(gr => gr.Groep)
                .IsRequired(false)
                .HasForeignKey<Groepstate>(g => g.GroepId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Klas)
                .HasColumnName("KLAS")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Naam)
                .HasColumnName("NAAM")
                .HasMaxLength(255)
                .IsUnicode(false);

//            builder.Property(g => g.Fout)
//                .IsRequired(false);
            builder.Property(e => e.Progress).HasColumnName("PROGRESS");

            
        }
    }
}