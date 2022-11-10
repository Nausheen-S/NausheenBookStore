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
        /*     public void Add(T entity)
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
             }*/
        //adding implementation
        public void Add(T entity)
        {
            dbSet.Add(entity);      // add context so classes correspond to the DbSet in ApplicationDbContext
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();      // returns the IEnumerable based on the conditions of the query
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();      // returns the IEnumerable based on the conditions of the query
        }

        public void Remove(int id)
        {
            T entity = dbSet.Find(id);
            Remove(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public void RemoveRange(IQueryable<T> entity)
        {
            throw new NotImplementedException();
        }
    }
}
