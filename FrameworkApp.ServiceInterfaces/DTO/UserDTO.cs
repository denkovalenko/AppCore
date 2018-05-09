using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.ServiceInterfaces.DTO
{
    public class UserDTO
    {
        public Int32 UserId { get; set; }
        public String Password { get; set; }

        public String Name { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
    }
}
