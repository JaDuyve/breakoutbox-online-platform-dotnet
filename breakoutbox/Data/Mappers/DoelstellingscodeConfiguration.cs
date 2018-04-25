using breakoutbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace breakoutbox.Data.Mappers
{
    public class DoelstellingscodeConfiguration:IEntityTypeConfiguration<Doelstellingscode>
    {
        public void Configure(EntityTypeBuilder<Doelstellingscode> builder)
        {
            builder.HasKey(e => e.Code);

            builder.ToTable("DOELSTELLINGSCODE");

            builder.Property(e => e.Code)
                .HasColumnName("CODE")
                .HasMaxLength(255)
                .IsUnicode(false)
                .ValueGeneratedNever();        }
    }
}