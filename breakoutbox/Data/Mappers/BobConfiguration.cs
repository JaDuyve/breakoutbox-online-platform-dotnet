using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class BobConfiguration:IEntityTypeConfiguration<Bob>
    {
        public void Configure(EntityTypeBuilder<Bob> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}