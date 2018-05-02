using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class GroepstateConfiguration : IEntityTypeConfiguration<Groepstate>
    {
        public void Configure(EntityTypeBuilder<Groepstate> builder)
        {
            builder.ToTable("GROEPSTATE");

            builder.HasKey(g => g.Id);

//            builder.Property(gr => gr.Id)
//                .ValueGeneratedOnAdd();
            
            builder.HasOne(d => d.Groep)
                .WithOne(g => g.Currentstate)
                .HasForeignKey<Groep>(g => g.CurrentstateId)
                .OnDelete(DeleteBehavior.Cascade);
            
            
            
            builder.HasDiscriminator<string>("type")
                .HasValue<Groepfinishedstate>("finish")
                .HasValue<Groepgeblokkeerdstate>("blok")
                .HasValue<Groepgekozenstate>("gekozen")
                .HasValue<Groepkanspelenstate>("kanspelen")
                .HasValue<Groepspeelstate>("spelen");
        }
    }
}