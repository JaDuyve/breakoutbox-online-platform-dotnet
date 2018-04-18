using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class ActieConfiguration:IEntityTypeConfiguration<Actie>
    {
        public void Configure(EntityTypeBuilder<Actie> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}