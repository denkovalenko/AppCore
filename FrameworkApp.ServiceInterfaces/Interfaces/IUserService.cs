using FrameworkApp.ServiceInterfaces.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.ServiceInterfaces.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUser(String email);
    }
}
