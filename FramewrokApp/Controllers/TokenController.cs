using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FrameworkApp.DependencyInjection.ViewModels.User;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using FrameworkApp.ServiceInterfaces.Interfaces;
using FrameworkApp.ServiceInterfaces.DTO.JWT;
using System.Net.Http.Headers;
using Microsoft.Net.Http.Headers;
using AutoMapper;

namespace FramewrokApp.Controllers
{
    [Route("api/Token")]
    public class TokenController : GenericController
    {
        public TokenController(IServiceFactory _serviceFactory, IMapper _mapper) : base(_serviceFactory, _mapper)
        {
        }

        [HttpPost]
        [Route("CreateToken")]
        public IActionResult CreateToken([FromBody] LoginViewModel login)
        {
            JwtResult result = serviceFactory.TokenService.CreatejwtSecurityToken(login.UserName, login.Password);

            return Ok(result);
        }

    }
}