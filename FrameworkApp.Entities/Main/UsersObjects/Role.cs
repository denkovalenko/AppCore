using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.Entities.Main.UsersObjects
{
    public class Role
    {
        public Int32 RoleId { get; set; }
        public String Name { get; set; }

        public List<User> Users { get; set; }
    }
}
