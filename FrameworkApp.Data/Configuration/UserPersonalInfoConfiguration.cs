using FrameworkApp.Entities.Main.UsersObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.Data.Configuration
{
    public class UserPersonalInfoConfiguration : IEntityTypeConfiguration<UserPersonalInfo>
    {
        public void Configure(EntityTypeBuilder<UserPersonalInfo> builder)
        {
            builder.HasKey(s => s.UserPersonalInfoId);

            builder.Property(s => s.Name)
                   .HasMaxLength(50);

            builder.Property(s => s.LastName)
                   .HasMaxLength(50);

            builder.Property(s => s.Email)
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }
}
