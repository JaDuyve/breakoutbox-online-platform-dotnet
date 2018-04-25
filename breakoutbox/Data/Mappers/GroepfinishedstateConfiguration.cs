using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class GroepfinishedstateConfiguration:IEntityTypeConfiguration<Groepfinishedstate>
    {
        public void Configure(EntityTypeBuilder<Groepfinishedstate> builder)
        {
            builder.ToTable("GROEPFINISHEDSTATE");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasColumnType("numeric(19, 0)");

            builder.HasOne(d => d.IdNavigation)
                .WithOne(p => p.Groepfinishedstate)
                .HasForeignKey<Groepfinishedstate>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GROEPFINISHEDSTATE_ID");
        }
    }
}