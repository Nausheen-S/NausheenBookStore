using NausheenBooks.DataAccess.Repository.IRepository; //adding dependency
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
//adding using statements
using NausheenBookStore.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace NausheenBooks.DataAccess.Repository
{
    //add implementation for interface
    public class Repository<T> : IRepository<T> where T : class
    {
        //add constructor and DI
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IQueryable<T> entity)
        {
            throw new NotImplementedException();
        }
    }
}
