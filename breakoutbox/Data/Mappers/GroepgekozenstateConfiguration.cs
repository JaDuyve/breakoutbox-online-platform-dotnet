using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class GroepgekozenstateConfiguration:IEntityTypeConfiguration<Groepgekozenstate>
    {
        public void Configure(EntityTypeBuilder<Groepgekozenstate> builder)
        {
            builder.ToTable("GROEPGEKOZENSTATE");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasColumnType("numeric(19, 0)");

            builder.HasOne(d => d.IdNavigation)
                .WithOne(p => p.Groepgekozenstate)
                .HasForeignKey<Groepgekozenstate>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GROEPGEKOZENSTATE_ID");
        }
    }
}