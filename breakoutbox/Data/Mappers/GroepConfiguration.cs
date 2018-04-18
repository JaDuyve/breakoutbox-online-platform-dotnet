using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class GroepConfiguration:IEntityTypeConfiguration<Groep>
    {
        public void Configure(EntityTypeBuilder<Groep> builder)
        {
            builder.ToTable("Groep");

//            builder.HasKey(t => t.Id);

//            builder.Property(g => g.Leerlingen);
//            builder.HasMany(g => g.Paden)
//                .WithOne();
        }
    }
}