using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FramewrokApp.Models
{
    public class UserViewModel
    {
        public Int32 UserId { get; set; }
        public String Password { get; set; }

        public String Name { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
    }
}
