using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.Entities.Main.UsersObjects
{
    public class UserRole
    {
        public Int32 UserId { get; set; }
        public Int32 RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
