using FrameworkApp.RepositoryInterfaces.ObjectInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.RepositoryInterfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; set; }
        Int32 SaveChanges();
    }
}
