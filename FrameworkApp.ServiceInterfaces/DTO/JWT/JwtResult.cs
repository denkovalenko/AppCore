using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.ServiceInterfaces.DTO.JWT
{
    public class JwtResult
    {
        public JwtToken JwtToken { get; set; }
        public String Error { get; set; }
    }
}
