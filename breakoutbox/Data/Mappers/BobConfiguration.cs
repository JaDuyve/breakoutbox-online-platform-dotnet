using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class BobConfiguration:IEntityTypeConfiguration<Bob>
    {
        public void Configure(EntityTypeBuilder<Bob> builder)
        {
            builder.ToTable("Bob");

            builder.HasKey(t => t.Naam);
        }
    }
}