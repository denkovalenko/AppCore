using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FrameworkApp.DependencyInjection.ViewModels.User;
using FrameworkApp.ServiceInterfaces.DTO;
using FrameworkApp.ServiceInterfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FramewrokApp.Controllers
{
    [Route("api/User")]
    public class UserController : GenericController
    {
        public UserController(IServiceFactory _serviceFactory, IMapper mapper) : base(_serviceFactory, mapper)
        {
        }

        [HttpGet]
        [Route("GetUserInfo")]
        public IActionResult GetUserInfo()
        {
            UserDTO user = serviceFactory.UserService.GetUser(UserInfo().UserName);
            UserInfoViewModel userInfo = _mapper.Map<UserInfoViewModel>(user);
            return Ok(userInfo);
        }

    }
}