using FrameworkApp.Data.BaseRepository;
using FrameworkApp.Data.Context;
using FrameworkApp.Entities.Main.UsersObjects;
using FrameworkApp.RepositoryInterfaces.ObjectInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkApp.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext _context) : base(_context)
        {
        }

        public User GetByUserName(String userName)
        {
            return Query.Include(s => s.UserPersonalInfo)
                        .Include(s=> s.Role)
                        .Where(s => s.UserPersonalInfo.Email == userName).FirstOrDefault();
        }


        public User GetUser(String userName, String password)
        {
            return Query.Include(s=> s.Role)
                        .Include(s=> s.UserPersonalInfo)
                        .Where(s => s.UserPersonalInfo.Email == userName && s.Password == password).FirstOrDefault();
        }
    }
}
