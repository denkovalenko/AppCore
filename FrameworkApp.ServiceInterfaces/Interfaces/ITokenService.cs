using FrameworkApp.ServiceInterfaces.DTO.JWT;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.ServiceInterfaces.Interfaces
{
    public interface ITokenService
    {
        JwtResult CreatejwtSecurityToken(String userName, String password);
    }
}
