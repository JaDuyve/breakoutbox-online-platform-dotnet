using breakoutbox.Models;
using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class GroepsBewerkingConfiguration:IEntityTypeConfiguration<Groepsbewerking>
    {
        public void Configure(EntityTypeBuilder<Groepsbewerking> builder)
        {
            builder.ToTable("Groepsbewerking");

            builder.HasKey(t => t.Naam);
        }
    }
}