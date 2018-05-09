﻿using AutoMapper;
using FrameworkApp.Entities.Main.UsersObjects;
using FrameworkApp.ServiceInterfaces.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.DependencyInjection.MapperConfiguration
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            #region domail to dto
            CreateMap<User, UserDTO>()
                .ForMember(s => s.Name, x => x.MapFrom(z => z.UserPersonalInfo.Name))
                .ForMember(s => s.LastName, x => x.MapFrom(z => z.UserPersonalInfo.LastName))
                .ForMember(s => s.Email, x => x.MapFrom(z => z.UserPersonalInfo.Email));
            #endregion

            //#region dto to view model
            //CreateMap<UserDTO, UserViewModel>();
            //#endregion
        }
    }
}