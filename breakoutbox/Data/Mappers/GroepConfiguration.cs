using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class GroepConfiguration:IEntityTypeConfiguration<Groep>
    {
        public void Configure(EntityTypeBuilder<Groep> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}