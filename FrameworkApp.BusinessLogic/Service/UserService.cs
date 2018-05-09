using AutoMapper;
using FrameworkApp.Entities.Main.UsersObjects;
using FrameworkApp.RepositoryInterfaces.UoW;
using FrameworkApp.ServiceInterfaces.DTO;
using FrameworkApp.ServiceInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.BusinessLogic.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork uow;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork _uow, IMapper mapper)
        {
            uow = _uow;
            _mapper = mapper;
        }

        public UserDTO GetUser()
        {
            User user = uow.UserRepository.GetByUserName("starvladislav@gmail.com");
            UserDTO dto = _mapper.Map<UserDTO>(user);
            return dto;
            //return new UserDTO() { UserId = user.UserId };
        }
    }
}
