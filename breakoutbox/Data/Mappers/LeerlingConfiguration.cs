using breakoutbox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class LeerlingConfiguration: IEntityTypeConfiguration<Leerling>
    {
        public void Configure(EntityTypeBuilder<Leerling> builder)
        {
            builder.ToTable("LEERLING");
            
            builder.HasKey(l => l.Id);
            
            
        }
    }
}