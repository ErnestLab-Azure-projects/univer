using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univer.Models;

namespace Univer.Data
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(s => s.StudentId);
            builder.Property(s => s.StudentId).HasColumnType("int");

            builder.Property(s => s.StudentFirstName).HasColumnType("nvarchar(50)").HasMaxLength(50);

            builder.Property(s => s.StudentLastName).HasColumnType("nvarchar(50)").HasMaxLength(50);

            builder.Property(s => s.StudentAge).HasColumnType("int");

            builder.Property(s => s.StudentRate).HasColumnType("float");

            builder.Property(s => s.FacultyId).IsRequired().HasColumnType("int");
            builder.HasOne(s => s.Faculty).WithMany(f => f.Students).HasForeignKey(s => s.FacultyId);

            builder.Property(s => s.GroupId).IsRequired().HasColumnType("int");
            builder.HasOne(s => s.Group).WithMany(g => g.Students).HasForeignKey(s => s.GroupId);

            builder.Property(s => s.UserId).IsRequired().HasColumnType("nvarchar(450)");
            builder.HasOne(s => s.User).WithMany(au => au.Students).HasForeignKey(s => s.UserId);
        }
    }
}
