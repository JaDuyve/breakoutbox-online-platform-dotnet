using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class GroepsBewerkingConfiguration:IEntityTypeConfiguration<Groepsbewerking>
    {
        public void Configure(EntityTypeBuilder<Groepsbewerking> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}