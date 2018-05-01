using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
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

//            builder.HasMany(g => g.Leerlingen)
//                .WithOne()
//                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(g => g.Currentstate)
                .WithOne(gr => gr.Groep)
                .HasForeignKey<Groepstate>(gr => gr.GroepId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Klas)
                .HasColumnName("KLAS")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Naam)
                .HasColumnName("NAAM")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Progress).HasColumnName("PROGRESS");

            
        }
    }
}