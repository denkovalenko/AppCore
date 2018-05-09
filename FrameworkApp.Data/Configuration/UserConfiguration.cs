using FrameworkApp.Entities.Main.UsersObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(s => s.UserId);
            builder.Property(s => s.Password);

            builder.HasOne(s => s.UserPersonalInfo)
                .WithOne(s => s.User)
                .HasForeignKey<UserPersonalInfo>(s => s.UserPersonalInfoId);
        }
    }
}
