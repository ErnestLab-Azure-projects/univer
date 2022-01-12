using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univer.Models;

namespace Univer.Data
{
    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.ToTable("Faculties");
            builder.HasKey(f => f.FacultyId);
            builder.Property(f => f.FacultyId).HasColumnType("int");

            builder.HasIndex(f => f.FacultyName).IsUnique();
            builder.Property(f => f.FacultyName).HasColumnType("nvarchar(100)").HasMaxLength(100);
        }
    }
}
