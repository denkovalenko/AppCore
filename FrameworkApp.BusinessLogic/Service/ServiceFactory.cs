using FrameworkApp.ServiceInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.BusinessLogic.Service
{
    public class ServiceFactory : IServiceFactory
    {
        public IUserService UserService { get; }
        public ITokenService TokenService { get; }

        public ServiceFactory(IUserService _userService, ITokenService _tokenService)
        {
            UserService = _userService;
            TokenService = _tokenService;
        }


    }
}
