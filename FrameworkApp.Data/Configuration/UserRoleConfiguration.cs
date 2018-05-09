using FrameworkApp.Entities.Main.UsersObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.Data.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(s => new { s.UserId, s.RoleId });

            builder.HasOne(s => s.Role)
                   .WithMany(s => s.UserRoles)
                   .HasForeignKey(s => s.RoleId);

            builder.HasOne(s => s.User)
                   .WithMany(s => s.UserRoles)
                   .HasForeignKey(s => s.UserId);
        }
    }
}
