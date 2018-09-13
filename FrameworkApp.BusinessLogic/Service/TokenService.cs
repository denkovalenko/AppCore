using AutoMapper;
using FrameworkApp.Common.Constants;
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

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtConst.SECURITY_KEY));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                                            issuer: JwtConst.ISSUER,
                                            audience: JwtConst.AUDIENCE,
                                            claims: claims,
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

        public ClaimsPrincipal GetClaims(String token)
        {
            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();

            SecurityToken validatedToken;
            var validateParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = JwtConst.ISSUER,
                ValidAudience = JwtConst.AUDIENCE,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtConst.SECURITY_KEY))
            };

            ClaimsPrincipal claimsPrincipal = securityTokenHandler.ValidateToken(token, validateParameters, out validatedToken);

            return claimsPrincipal;
        }
    }
}
