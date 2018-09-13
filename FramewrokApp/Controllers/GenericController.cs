using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FrameworkApp.DependencyInjection.ViewModels.User;
using FrameworkApp.ServiceInterfaces.DTO;
using FrameworkApp.ServiceInterfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace FramewrokApp.Controllers
{
    public class GenericController : Controller
    {
        public readonly IServiceFactory serviceFactory;
        public readonly IMapper _mapper;
        public GenericController(IServiceFactory _serviceFactory, IMapper mapper)
        {
            serviceFactory = _serviceFactory;
            _mapper = mapper;
        }


        public UserClaimsViewModel UserInfo()
        {
            return new UserClaimsViewModel
            {
                UserName = GetClaims().Identity.Name,
                UserRole = GetClaims().Claims.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault().Value
            };
        }
        
        private ClaimsPrincipal GetClaims()
        {
            AuthenticationHeaderValue authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers[HeaderNames.Authorization]);
            ClaimsPrincipal claims = serviceFactory.TokenService.GetClaims(authenticationHeaderValue.Parameter);
            return claims;
        }

    }
}