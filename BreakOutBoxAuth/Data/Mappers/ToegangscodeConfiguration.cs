﻿using BreakOutBoxAuth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBoxAuth.Data.Mappers
{
    public class ToegangscodeConfiguration : IEntityTypeConfiguration<Toegangscode>
    {
        public void Configure(EntityTypeBuilder<Toegangscode> builder)
        {
            builder.ToTable("TOEGANGSCODE");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasColumnType("numeric(19, 0)")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Code).HasColumnName("CODE");
        }
    }
}