using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class ActieConfiguration:IEntityTypeConfiguration<Actie>
    {
        public void Configure(EntityTypeBuilder<Actie> builder)
        {
            builder.ToTable("Actie");

            builder.HasKey(t => t.Naam);

        }
    }
}