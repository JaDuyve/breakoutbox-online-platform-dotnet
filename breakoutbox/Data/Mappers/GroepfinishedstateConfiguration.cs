using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class GroepfinishedstateConfiguration : IEntityTypeConfiguration<Groepfinishedstate>
    {
        public void Configure(EntityTypeBuilder<Groepfinishedstate> builder)
        {
            builder.Property(f => f.IdF);



        }
    }
}