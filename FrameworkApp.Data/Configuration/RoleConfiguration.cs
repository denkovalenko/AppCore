using FrameworkApp.Entities.Main.UsersObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.Data.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(s => s.RoleId);
            builder.Property(s => s.Name)
                   .HasColumnName("Name")
                   .HasMaxLength(50);

        }
    }
}
