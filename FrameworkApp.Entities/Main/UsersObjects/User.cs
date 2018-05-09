using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.Entities.Main.UsersObjects
{
    public class User
    {
        public Int32 UserId { get; set; }
        public String Password { get; set; }

        public UserPersonalInfo UserPersonalInfo { get; set; }
    }
}
