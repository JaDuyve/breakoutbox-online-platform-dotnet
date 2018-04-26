using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class GroepspeelstateConfiguration:IEntityTypeConfiguration<Groepspeelstate>
    {
        public void Configure(EntityTypeBuilder<Groepspeelstate> builder)
        {
            builder.ToTable("GROEPSPEELSTATE");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasColumnType("numeric(19, 0)");

            builder.HasOne(d => d.IdNavigation)
                .WithOne(p => p.Groepspeelstate)
                .HasForeignKey<Groepspeelstate>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GROEPSPEELSTATE_ID");
        }
    }
}