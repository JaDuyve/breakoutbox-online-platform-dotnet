using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class GroepstateConfiguration:IEntityTypeConfiguration<Groepstate>
    {
        public void Configure(EntityTypeBuilder<Groepstate> builder)
        {
            builder.ToTable("GROEPSTATE");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasColumnType("numeric(19, 0)")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Dtype)
                .HasColumnName("DTYPE")
                .HasMaxLength(31)
                .IsUnicode(false);

            builder.Property(e => e.GroepId)
                .HasColumnName("GROEP_ID")
                .HasColumnType("numeric(19, 0)");

            builder.HasOne(d => d.GroepNavigation)
                .WithMany(p => p.Groepstate)
                .HasForeignKey(d => d.GroepId)
                .HasConstraintName("FK_GROEPSTATE_GROEP_ID");
        }
    }
}