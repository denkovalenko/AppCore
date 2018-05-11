using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.Entities.Main.UsersObjects
{
    public class UserPersonalInfo
    {
        public Int32 UserPersonalInfoId { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }

        public User User { get; set; }
    }   
}
