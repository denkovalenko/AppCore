using AutoMapper;
using FrameworkApp.DependencyInjection.ViewModels.User;
using FrameworkApp.Entities.Main.UsersObjects;
using FrameworkApp.ServiceInterfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkApp.DependencyInjection.MapperConfiguration
{
    internal class MappingConfig : Profile
    {
        public MappingConfig()
        {
            #region domail to dto
            CreateMap<User, UserDTO>()
                .ForMember(s => s.Name, x => x.MapFrom(z => z.UserPersonalInfo.Name))
                .ForMember(s => s.LastName, x => x.MapFrom(z => z.UserPersonalInfo.LastName))
                .ForMember(s => s.Email, x => x.MapFrom(z => z.UserPersonalInfo.Email))
                .ForMember(s => s.RoleId, x => x.MapFrom(z => z.Role.RoleId));
            #endregion

            #region dto to view model
            CreateMap<UserDTO, UserViewModel>();
            #endregion
        }
    }
}
