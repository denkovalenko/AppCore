using AutoMapper;
using FrameworkApp.Entities.Main.UsersObjects;
using FrameworkApp.RepositoryInterfaces.UoW;
using FrameworkApp.ServiceInterfaces.DTO.JWT;
using FrameworkApp.ServiceInterfaces.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FrameworkApp.BusinessLogic.Service
{
    public class TokenService : ITokenService
    {
        private IUnitOfWork uow;
        private readonly IMapper _mapper;
        private const String securityKey = "key";

        public TokenService(IUnitOfWork _uow, IMapper mapper)
        {
            uow = _uow;
            _mapper = mapper;
        }

        public JwtResult CreatejwtSecurityToken(String userName, String password)
        {
            JwtResult result = new JwtResult();

            User user = uow.UserRepository.GetUser(userName, password);
            if(user == null)
            {
                result.Error = "Invalid username or password";
                return result;
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserPersonalInfo.Email),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("key"));
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //var creds = new SigningCredentials(
            //    key,
            //    "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
            //    "http://www.w3.org/2001/04/xmlenc#sha256");

            //var token = new JwtSecurityToken(
            //                                issuer: "yourdomain.com",
            //                                audience: "yourdomain.com",
            //                                claims: claims,
            //                                expires: DateTime.Now.AddMinutes(30),
            //                                signingCredentials: creds);
            var token = new JwtSecurityToken(claims: claimsIdentity.Claims,
                                notBefore: DateTime.Now,
                                expires: DateTime.Now.AddMinutes(30),
                                signingCredentials: creds);

            var tokenEncd = new JwtSecurityTokenHandler().WriteToken(token);

            result.JwtToken = new JwtToken
            {
                Token = tokenEncd,
                UserName = claimsIdentity.Name
            };

            return result;
        }
    }
}
