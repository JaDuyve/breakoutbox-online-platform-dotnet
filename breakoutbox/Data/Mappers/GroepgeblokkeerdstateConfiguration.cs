using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class GroepgeblokkeerdstateConfiguration:IEntityTypeConfiguration<Groepgeblokkeerdstate>
    {
        public void Configure(EntityTypeBuilder<Groepgeblokkeerdstate> builder)
        {
            builder.ToTable("GROEPGEBLOKKEERDSTATE");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasColumnType("numeric(19, 0)");

            builder.HasOne(d => d.IdNavigation)
                .WithOne(p => p.Groepgeblokkeerdstate)
                .HasForeignKey<Groepgeblokkeerdstate>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GROEPGEBLOKKEERDSTATED");
        }
    }
}