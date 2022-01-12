using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univer.Models;

namespace Univer.Data
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");
            builder.HasKey(g => g.GroupId);
            builder.Property(g => g.GroupId).HasColumnType("int");

            builder.HasIndex(g => g.GroupName).IsUnique();
            builder.Property(g => g.GroupName).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);
        }
    }
}
