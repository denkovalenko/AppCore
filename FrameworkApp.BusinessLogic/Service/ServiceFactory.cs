using FrameworkApp.ServiceInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.BusinessLogic.Service
{
    public class ServiceFactory : IServiceFactory
    {
        public IUserService UserService { get; }

        public ServiceFactory(IUserService _userService)
        {
            UserService = _userService;
        }


    }
}
