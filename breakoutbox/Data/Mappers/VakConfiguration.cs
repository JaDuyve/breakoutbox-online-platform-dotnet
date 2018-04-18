using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class VakConfiguration:IEntityTypeConfiguration<Vak>
    {
        public void Configure(EntityTypeBuilder<Vak> builder)
        {
            builder.ToTable("Vak");

            builder.HasKey(t => t.Naam);
        }
    }
}