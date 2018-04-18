using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class PadConfiguration:IEntityTypeConfiguration<Pad>
    {
        public void Configure(EntityTypeBuilder<Pad> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}