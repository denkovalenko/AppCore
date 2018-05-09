using FrameworkApp.Data.Context;
using FrameworkApp.RepositoryInterfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkApp.Data.BaseRepository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private AppDbContext context;
        private DbSet<T> entities;

        public BaseRepository(AppDbContext _context)
        {
            context = _context;
            entities = context.Set<T>();
        }

        public T GetById(object id)
        {
            return entities.Find(id);
        }

        public IQueryable<T> Query
        {
            get
            {
                return entities;
            }
        }

        public void InsertOrUpdateGraph(T item)
        {
            context.Update(item);
        }

        public void Remove(T item)
        {
            context.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public Int32 SaveChanges()
        {
            return context.SaveChanges();
        }


    }
}
