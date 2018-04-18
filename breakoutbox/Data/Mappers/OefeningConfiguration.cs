using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class OefeningConfiguration: IEntityTypeConfiguration<Oefening>
    {
        public void Configure(EntityTypeBuilder<Oefening> builder)
        {
            builder.ToTable("Oefening");

            builder.HasKey(t => t.Naam);
        }
    }
}