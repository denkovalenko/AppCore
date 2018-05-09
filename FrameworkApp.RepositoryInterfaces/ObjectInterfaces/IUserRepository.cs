using FrameworkApp.Entities.Main.UsersObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.RepositoryInterfaces.ObjectInterfaces
{
    public interface IUserRepository
    {
        User GetByUserName(String userName);
        User GetUser(String userName, String password);
    }
}
