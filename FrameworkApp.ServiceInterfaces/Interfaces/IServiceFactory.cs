using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.ServiceInterfaces.Interfaces
{
    public interface IServiceFactory
    {
        IUserService UserService { get; }
        ITokenService TokenService { get;}
    }
}
