﻿using FrameworkApp.Data.Context;
using FrameworkApp.Data.Repository;
using FrameworkApp.RepositoryInterfaces.ObjectInterfaces;
using FrameworkApp.RepositoryInterfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext context;

        public IUserRepository UserRepository { get; set; }

        public UnitOfWork(AppDbContext _context)
        {
            context = _context;

            UserRepository = new UserRepository(_context);
        }

        public Int32 SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
