using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class ToegangscodeConfiguration:IEntityTypeConfiguration<Toegangscode>
    {
        public void Configure(EntityTypeBuilder<Toegangscode> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}