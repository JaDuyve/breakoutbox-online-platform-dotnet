using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class GroepkanspelenstateConfiguration:IEntityTypeConfiguration<Groepkanspelenstate>
    {
        public void Configure(EntityTypeBuilder<Groepkanspelenstate> builder)
        {
            builder.ToTable("GROEPKANSPELENSTATE");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasColumnType("numeric(19, 0)");

            builder.HasOne(d => d.IdNavigation)
                .WithOne(p => p.Groepkanspelenstate)
                .HasForeignKey<Groepkanspelenstate>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GROEPKANSPELENSTATE_ID");
        }
    }
}